using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetFilBleu_AppBureauxDEtudes.DTOs;
using ProjetFilBleu_AppBureauxDEtudes.Entities;
using ProjetFilBleu_AppBureauxDEtudes.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ProjetFilBleu_AppBureauxDEtudes.Controllers
{
    [ApiController]
    [Route("articles")]
    public class ArticlesController : BaseController<Article>
    {
        [HttpGet("byCategoryId/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            List<Article> articles = new List<Article>();
            articles = await JadServices.GetArticles();
            articles = articles.Where(a => a.CategoryId == categoryId).ToList();
            if (articles == null)
                return new StatusCodeResult(500);

            return new JsonResult(JsonConvert.SerializeObject(articles));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]string articleJson)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(articleJson))
                    return new BadRequestObjectResult("Aucun article n'a été envoyé dans la requête");
                ArticleToCreate article = JsonConvert.DeserializeObject<ArticleToCreate>(articleJson);

                string response = await JadServices.PostArticle(article);
                if (response != "Success")
                    return new BadRequestObjectResult(response);

                return new OkResult();
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost("product/{id}/{quantity?}")]
        public async Task<IActionResult> PostProductArticleAsync(int id, int quantity = 1)
        {
            try
            {
                Article article = await JadServices.GetArticleById(id);
                if (article == null)
                    return new NotFoundObjectResult("Aucun article existant avec cet ID");

                ArticleProductionTreeElement articleProductionTree = new ArticleProductionTreeElement();

                Recipe articleRecipe = await JadServices.GetRecipeByArticleId(article.Id);
                if (articleRecipe == null)
                    return new NotFoundObjectResult("Impossible de trouver la recette de cet article");

                articleProductionTree.Id = article.Id;
                articleProductionTree.Quantity = quantity;
                articleProductionTree.Code = article.Code;
                articleProductionTree = await SetArticleRecipe(articleRecipe, articleProductionTree);

                bool sendResult = await ProductionServices.SendProductionNotification(articleProductionTree);

                if (!sendResult)
                    return new BadRequestObjectResult("Un problème est intervenu lors de l'envoi de l'ordre de production de l'article");

                return new OkResult();
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }

        private async Task<ArticleProductionTreeElement> SetArticleRecipe(Recipe articleRecipe, ArticleProductionTreeElement articleProductionTree)
        {
            try
            {
                ArticleProductionTreeElementRecipe articleProductionTreeElementRecipe = new ArticleProductionTreeElementRecipe();
                ArticleProductionTreeElement firstComponent = new ArticleProductionTreeElement();
                ArticleProductionTreeElement secondComponent = new ArticleProductionTreeElement();

                if (articleRecipe.SecondComponentId == null && articleRecipe.FirstComponentId == null)
                    articleProductionTreeElementRecipe = null;
                else
                {
                    Article firstComponentArticle = await JadServices.GetArticleById((int)articleRecipe.FirstComponentId);
                    if (firstComponentArticle == null)
                        articleProductionTreeElementRecipe = null;
                    else
                    {
                        articleProductionTreeElementRecipe.OperationId = articleRecipe.OperationId;

                        firstComponent.Id = firstComponentArticle.Id;
                        firstComponent.Quantity = (int)articleRecipe.FirstComponentQuantity * articleProductionTree.Quantity;
                        firstComponent.Code = firstComponentArticle.Code;

                        Recipe firstComponentRecipe = await JadServices.GetRecipeByArticleId(firstComponentArticle.Id);
                        if (firstComponentRecipe == null)
                            firstComponent.Recipe = null;
                        else
                            firstComponent = await SetArticleRecipe(firstComponentRecipe, firstComponent);

                        articleProductionTreeElementRecipe.FirstComponent = firstComponent;

                        if (articleRecipe.SecondComponentId != null)
                        {
                            Article secondComponentArticle = await JadServices.GetArticleById((int)articleRecipe.SecondComponentId);
                            if (secondComponentArticle == null)
                                articleProductionTreeElementRecipe.SecondComponent = null;
                            else
                            {
                                articleProductionTreeElementRecipe.OperationId = articleRecipe.OperationId;

                                secondComponent.Id = secondComponentArticle.Id;
                                secondComponent.Quantity = (int)articleRecipe.SecondComponentQuantity * articleProductionTree.Quantity;
                                secondComponent.Code = secondComponentArticle.Code;

                                Recipe secondComponentRecipe = await JadServices.GetRecipeByArticleId(secondComponentArticle.Id);
                                if (secondComponentRecipe == null)
                                    secondComponent.Recipe = null;
                                else
                                    secondComponent = await SetArticleRecipe(secondComponentRecipe, secondComponent);

                                articleProductionTreeElementRecipe.SecondComponent = secondComponent;
                            }
                        }
                        else
                            articleProductionTreeElementRecipe.SecondComponent = null;
                    }
                }

                articleProductionTree.Recipe = articleProductionTreeElementRecipe;

                return articleProductionTree;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

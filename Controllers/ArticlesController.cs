using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetFilBleu_AppBureauxDEtudes.DTOs;
using ProjetFilBleu_AppBureauxDEtudes.Entities;
using ProjetFilBleu_AppBureauxDEtudes.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            articles = await JadServices.GetArticlesByCategoryId(categoryId);
            if (articles == null)
                return new StatusCodeResult(500);

            return new JsonResult(JsonConvert.SerializeObject(articles));
        }

        public async Task<IActionResult> PostAsync(string articleJson)
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
    }
}

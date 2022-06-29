using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjetFilBleu_AppBureauxDEtudes.Controllers;
using ProjetFilBleu_AppBureauxDEtudes.DTOs;
using ProjetFilBleu_AppBureauxDEtudes.Entities;
using ProjetFilBleu_AppBureauxDEtudes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CallJadServices();
            CreateHostBuilder(args).Build().Run();
        }

        public static async void CallJadServices()
        {
            //Article article = await JadServices.GetArticleById(13);
            //Recipe recipe = await JadServices.GetRecipeByArticleId(2);
            //List<Article> articles = await JadServices.GetArticles();
            //List<Category> categories = await JadServices.GetCategories();
            //List<Operation> operations = await JadServices.GetOperations();
            //List<Recipe> recipes = await JadServices.GetRecipes();
            //ArticleToCreate articleToCreate = new ArticleToCreate
            //{
            //    codeArticle = "D205541551",
            //    codeCategorie = categories.First().Label,
            //    codeOperation = operations.First().Code,
            //    articles = new ArticleToCreateChildArticle[] { new ArticleToCreateChildArticle { codeArticle = "P361603178", quantite = 3 }, new ArticleToCreateChildArticle { codeArticle = "P736540925", quantite = 8 } }
            //};
            //await JadServices.PostArticle(articleToCreate);
            bool wait = false;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

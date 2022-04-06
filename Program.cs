using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
            List<Article> articles = await JadServices.GetArticles();
            List<Category> categories = await JadServices.GetCategories();
            List<Operation> operations = await JadServices.GetOperations();
            List<Recipe> recipes = await JadServices.GetRecipes();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

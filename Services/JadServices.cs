using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjetFilBleu_AppBureauxDEtudes.DTOs;
using ProjetFilBleu_AppBureauxDEtudes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Services
{
    public static class JadServices
    {
        private static string baseUrl = "http://88.168.248.140:8000/";

        public static async Task<List<Article>> GetArticles()
        {
            HttpClient client = new HttpClient();
            string url = baseUrl + "articles";
            HttpResponseMessage response = await client.GetAsync(url);
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                return null;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Article>>(result);
        }

        public static async Task<Article> GetArticleById(int id)
        {
            if (id !< 0)
                return null;
            HttpClient client = new HttpClient();
            string url = baseUrl + "articles/" + id;
            HttpResponseMessage response = await client.GetAsync(url);
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                return null;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Article>(result);
        }

        public static async Task<List<Article>> GetArticlesByCategoryId(int categoryId)
        {
            if (categoryId !> 0)
                return null;
            HttpClient client = new HttpClient();
            string url = baseUrl + "articles/bycategory/" + categoryId;
            HttpResponseMessage response = await client.GetAsync(url);
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                return null;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Article>>(result);
        }

        public static async Task<string> PostArticle(ArticleToCreate article)
        {
            if (!article.VerifyArticleToCreate())
                return "L'article que vous souhaitez créer n'est pas valide. Vérifiez bien que toutes les caractéristiques obligatoires sont bien renseignées";
            HttpClient client = new HttpClient();
            string url = baseUrl + "articles";
            StringContent requestContent = new StringContent(JsonConvert.SerializeObject(new ArticleToCreate[] { article }));
            requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(url, requestContent);
            if (!(response.StatusCode == System.Net.HttpStatusCode.Created))
                return null;
            return "Success";
        }

        public static async Task<List<Category>> GetCategories()
        {
            HttpClient client = new HttpClient();
            string url = baseUrl + "categories";
            HttpResponseMessage response = await client.GetAsync(url);
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                return null;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Category>>(result);
        }

        public static async Task<Category> GetCategoryById(int id)
        {
            if (id !< 0)
                return null;
            HttpClient client = new HttpClient();
            string url = baseUrl + "categories/" + id;
            HttpResponseMessage response = await client.GetAsync(url);
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                return null;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Category>(result);
        }

        public static async Task<List<Recipe>> GetRecipes()
        {
            HttpClient client = new HttpClient();
            string url = baseUrl + "recipes";
            HttpResponseMessage response = await client.GetAsync(url);
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                return null;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Recipe>>(result);
        }

        public static async Task<Recipe> GetRecipeByArticleId(int articleId)
        {
            if (articleId! > 0)
                return null;
            HttpClient client = new HttpClient();
            string url = baseUrl + "recipes/" + articleId;
            HttpResponseMessage response = await client.GetAsync(url);
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                return null;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Recipe>(result);
        }

        public static async Task<List<Operation>> GetOperations()
        {
            HttpClient client = new HttpClient();
            string url = baseUrl + "operations";
            HttpResponseMessage response = await client.GetAsync(url);
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                return null;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Operation>>(result);
        }
    }
}

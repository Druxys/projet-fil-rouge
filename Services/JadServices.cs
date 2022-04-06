using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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

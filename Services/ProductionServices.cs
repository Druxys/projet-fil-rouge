using Microsoft.AspNetCore.Mvc;
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
    public class ProductionServices
    {
        private static string baseUrl = "https://localhost:44325/production";

        public static async Task<bool> SendProductionNotification(ArticleProductionTreeElement articleProductionTree)
        {
            HttpClient client = new HttpClient();
            string url = baseUrl;
            client.Timeout = TimeSpan.FromSeconds(900);
            StringContent requestContent = new StringContent(JsonConvert.SerializeObject(articleProductionTree));
            requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(url, requestContent);
            if (!(response.StatusCode == System.Net.HttpStatusCode.OK))
                return false;

            return true;
        }
    }
}

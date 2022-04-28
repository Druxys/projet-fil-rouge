using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetFilBleu_AppBureauxDEtudes.Entities;
using ProjetFilBleu_AppBureauxDEtudes.Services;
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
    }
}

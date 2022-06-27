using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetFilBleu_AppBureauxDEtudes.Entities;
using ProjetFilBleu_AppBureauxDEtudes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Controllers
{
    public class BaseController<E> where E : BaseEntity
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                E exampleEntity = (E)Activator.CreateInstance(typeof(E), null);
                List<E> entities = new List<E>();

                MethodInfo getMethod = typeof(JadServices).GetMethod("Get" + typeof(E).GetProperty("PluralName").GetValue(exampleEntity));
                if (getMethod == null)
                    return new StatusCodeResult(400);

                Task<List<E>> getMethodResult = (Task<List<E>>)getMethod.Invoke(null, null);
                entities = await getMethodResult;

                return new JsonResult(JsonConvert.SerializeObject(entities));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = new BaseEntity();
                if (typeof(E).IsAssignableFrom(typeof(Article)))
                {
                    entity = await JadServices.GetArticleById(id) as E;
                    if (entity == null)
                        return new StatusCodeResult(500);
                }
                else if (typeof(E).IsAssignableFrom(typeof(Category)))
                {
                    entity = await JadServices.GetCategoryById(id) as E;
                    if (entity == null)
                        return new StatusCodeResult(500);
                }

                if (entity == null)
                    return new NotFoundObjectResult("Aucune donnée existante avec cet ID");

                return new JsonResult(JsonConvert.SerializeObject(entity));

            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}

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
                List<E> entities = new List<E>();

                // try to generalize the get route
                //MethodInfo getMethod = typeof(JadServices).GetMethod("Get" + typeof(E).Name + "s");
                //if (getMethod == null)
                //    getMethod = typeof(JadServices).GetMethod("Get" + typeof(E).Name.Replace("y", "ies")); // for category (and maybe future properties which ends with ies when in plural

                //if (getMethod == null)
                //    return new StatusCodeResult(400);

                //Task<List<E>> getMethodResult = (Task<List<E>>)getMethod.Invoke(null, null);
                //entities = await getMethodResult;

                if (typeof(E).IsAssignableFrom(typeof(Article)))
                {
                    entities = await JadServices.GetArticles() as List<E>;
                    if (entities == null)
                        return new StatusCodeResult(500);
                }
                else if (typeof(E).IsAssignableFrom(typeof(Category)))
                {
                    entities = await JadServices.GetCategories() as List<E>;
                    if (entities == null)
                        return new StatusCodeResult(500);
                }
                else if (typeof(E).IsAssignableFrom(typeof(Operation)))
                {
                    entities = await JadServices.GetOperations() as List<E>;
                    if (entities == null)
                        return new StatusCodeResult(500);
                }
                else if (typeof(E).IsAssignableFrom(typeof(Recipe)))
                {
                    entities = await JadServices.GetRecipes() as List<E>;
                    if (entities == null)
                        return new StatusCodeResult(500);
                }

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

                return new JsonResult(JsonConvert.SerializeObject(entity));

            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}

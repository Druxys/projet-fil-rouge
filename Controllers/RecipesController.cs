using Microsoft.AspNetCore.Mvc;
using ProjetFilBleu_AppBureauxDEtudes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Controllers
{
    [ApiController]
    [Route("recipes")]
    public class RecipesController : BaseController<Recipe>
    {
    }
}

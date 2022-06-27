using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.DTOs
{
    public class ArticleProductionTreeElement
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public ArticleProductionTreeElementRecipe Recipe { get; set; }
        public bool Done { get; set; } = false;
    }

    public class ArticleProductionTreeElementRecipe
    {
        public ArticleProductionTreeElement FirstComponent { get; set; }
        public ArticleProductionTreeElement SecondComponent { get; set; }
        public int? OperationId { get; set; }
    }
}

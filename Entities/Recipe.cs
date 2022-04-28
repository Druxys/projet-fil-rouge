using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Entities
{
    public class Recipe
    {
        public Recipe()
        {
            PluralName = "Recipes";
        }

        public int ArticleId { get; set; }
        public int OperationId { get; set; }
        // les composants sont des articles
        public int FirstComponentId { get; set; } 
        public int FirstComponentQuantity { get; set; }
        public int? SecondComponentId { get; set; }
        public int? SecondComponentQuantity { get; set; }

        public int id_article 
        {
            get { return ArticleId; }
            set { ArticleId = value; }
        }
        public int id_operation
        {
            get { return OperationId; }
            set { OperationId = value; }
        }
        public int id_composant1
        {
            get { return FirstComponentId; }
            set { FirstComponentId = value; }
        }
        public int quantite1
        {
            get { return FirstComponentQuantity; }
            set { FirstComponentQuantity = value; }
        }
        public int? id_composant2
        {
            get { return SecondComponentId; }
            set { SecondComponentId = value; }
        }
        public int? quantite2
        {
            get { return SecondComponentQuantity; }
            set { SecondComponentQuantity = value; }
        }
    }
}

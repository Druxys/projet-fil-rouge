using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Entities
{
    public class Recipe : BaseEntity
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

        private int id_article 
        {
            get { return ArticleId; }
            set { ArticleId = value; }
        }
        private int id_operation
        {
            get { return OperationId; }
            set { OperationId = value; }
        }
        private int id_composant1
        {
            get { return FirstComponentId; }
            set { FirstComponentId = value; }
        }
        private int quantite1
        {
            get { return FirstComponentQuantity; }
            set { FirstComponentQuantity = value; }
        }
        private int? id_composant2
        {
            get { return SecondComponentId; }
            set { SecondComponentId = value; }
        }
        private int? quantite2
        {
            get { return SecondComponentQuantity; }
            set { SecondComponentQuantity = value; }
        }
    }
}

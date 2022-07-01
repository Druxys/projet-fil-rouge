using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Entities
{
    public class Article : BaseEntity
    {
        public Article()
        {
            PluralName = "Articles";
        }

        public string Code { get; set; }
        public string Label { get; set; }
        public int CategoryId { get; set; }

        [JsonProperty]
        private string code { 
            get { return Code; }
            set { Code = value; } 
        }

        [JsonProperty]
        private string libelle
        {
            get { return Label; }
            set { Label = value; }
        }

        [JsonProperty]
        private int id_categorie
        {
            get { return CategoryId; }
            set { CategoryId = value; }
        }
    }
}

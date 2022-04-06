using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Entities
{
    public class Article : BaseEntity
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public int CategoryId { get; set; }


        public string code { 
            get { return Code; }
            set { Code = value; } 
        }

        public string libelle
        {
            get { return Label; }
            set { Label = value; }
        }

        public int id_categorie
        {
            get { return CategoryId; }
            set { CategoryId = value; }
        }
    }
}

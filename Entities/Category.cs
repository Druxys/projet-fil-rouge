using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            PluralName = "Categories";
        }

        public string Code { get; set; }
        public string Label { get; set; }

        public string code
        {
            get { return Code; }
            set { Code = value; }
        }

        public string libelle
        {
            get { return Label; }
            set { Label = value; }
        }
    }
}

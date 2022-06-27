using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string PluralName { get; set; }

        private int id
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}

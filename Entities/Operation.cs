using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Entities
{
    public class Operation : BaseEntity
    {
        public Operation()
        {
            PluralName = "Operations";
        }

        public string Code { get; set; }
        public string Label { get; set; }
        public string Delay { get; set; }
        public string InstallationDelay { get; set; }

        [JsonProperty]
        private string code
        {
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
        private string delai
        {
            get { return Delay; }
            set { Delay = value; }
        }

        [JsonProperty]
        private string delaiInstallation
        {
            get { return InstallationDelay; }
            set { InstallationDelay = value; }
        }

    }
}

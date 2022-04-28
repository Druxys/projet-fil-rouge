using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilBleu_AppBureauxDEtudes.Entities
{
    public class Operation
    {
        public Operation()
        {
            PluralName = "Operations";
        }

        public string Code { get; set; }
        public string Label { get; set; }
        public string Delay { get; set; }
        public string InstallationDelay { get; set; }

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

        public string delai
        {
            get { return Delay; }
            set { Delay = value; }
        }

        public string delaiInstallation
        {
            get { return InstallationDelay; }
            set { InstallationDelay = value; }
        }

    }
}

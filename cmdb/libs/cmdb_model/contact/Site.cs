using System;
using System.Collections.Generic;
using System.Text;
using cmdb_model;
using cmdb_model.tools;

namespace cmdb_model.contact
{
    public class Site :_Core
    {
        public string Nom { get; set; }
        public Statut Statut { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
}

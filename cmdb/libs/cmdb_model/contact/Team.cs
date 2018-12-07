using System;
using System.Collections.Generic;
using System.Text;
using cmdb_model;
using cmdb_model.tools;
namespace cmdb_model.contact
{
    public class Team : _Core
    {
        public string Nom { get; set; }
        public string Fonction { get; set; }
        public Statut statut { get; set; }
        public string Email { get; set; }
        
        List<Person> Membres { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using cmdb_model;
using cmdb_model.tools;

namespace cmdb_model.contact
{
    public class Person : _Core
    {
        //Informations générales
        public string nom { get; set; }
        public string prenom { get; set; }
        public Statut statut { get; set; }
        public Site site { get; set; }
        public string fonction { get; set; }
        public Person manager { get; set; }

        //Informations personelles
        public string photo { get; set; }
        public string telephone_perso_fixe { get; set; }
        public string telephone_perso_mobile { get; set; }

        //Notifications
        public string email { get; set; }
        public bool notification { get; set; }
        public string telephone_pro_fixe { get; set; }
        public string telephone_pro_mobile { get; set; }

        //Onglets
        List<Team> teams { get; set; }
    }
}

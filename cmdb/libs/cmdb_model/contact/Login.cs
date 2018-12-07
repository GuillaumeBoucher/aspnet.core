using System;
using System.Collections.Generic;
using System.Text;
using cmdb_model;
using cmdb_model.tools;

namespace cmdb_model.contact
{
    public class Login : _Core
    {

        public string LoginType { get; set; }  //ldap //Interne //Externe
        public Person Person { get; set; }
        public string LoginName { get; set; }
        public string Passord { get; set; }   //password confirmé
        public string Passord1 { get; set; }  //saisie1
        public string Passord2 { get; set; }  //saisie2
        public Statut statut { get; set; }


    }
}

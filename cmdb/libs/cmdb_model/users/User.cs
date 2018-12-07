using System;
using System.Collections.Generic;
using System.Text;
using cmdb_model;

namespace cmdb_model.user
{
    public class User : _Core
    {
        
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Interne { get; set; }

        public List<Application> Applications { get; set; }
        public List<Role> Roles { get; set; }

    }
}

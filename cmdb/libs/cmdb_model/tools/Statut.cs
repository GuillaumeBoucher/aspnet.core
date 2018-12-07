using System;
using System.Collections.Generic;
using System.Text;
using cmdb_model;

namespace cmdb_model.tools
{
    public class Statut : _Core
    {
        public bool statut { get; set; }
        public string text
        { get
            {
                if (this.statut)
                {
                    return "Actif";
                }
                else
                {
                    return "Inactif";
                }
            }
        }
    }
}

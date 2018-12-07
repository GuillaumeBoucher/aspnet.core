using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmdb.Models
{
    public class User
    {
        public long Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
        public bool AgreeWith { get; set; }
    }
}

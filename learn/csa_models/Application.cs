using System;
using System.Collections.Generic;
using System.Text;

namespace csa_models
{
    public class Application : _Core
    {
        public string Name { get; set; }

        public List<Role> Roles { get; set; }

        public List<Role> Users { get; set; }
    }
}

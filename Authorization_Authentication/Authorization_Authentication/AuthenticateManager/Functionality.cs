using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_Authentication.AuthenticateManager
{
    public class Functionality
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Functionality_Role> Roles { get; set; }
    }
}
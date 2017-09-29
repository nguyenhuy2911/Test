using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_Authentication.AuthenticateManager
{
    public class UserProfile
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
    }
}
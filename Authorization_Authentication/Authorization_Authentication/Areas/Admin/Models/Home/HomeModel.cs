using Authorization_Authentication.AuthenticateManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_Authentication.Areas.Admin.Models
{
    public class HomeModel
    {
        public List<User> Users { get; set; }
    }
}
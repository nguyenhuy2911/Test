using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_Authentication.AuthenticateManager
{
    public class Role
    {        
        public int RoleID { get; set; }
        public string RoleName { get; set; }
       // public List<Functionality_Role> Functionalities { get; set; }
        public List<User_Role> Users { get; set; }
        public List<Functionality> Functionalities { get; set; }
    }
}
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_Authentication.AuthenticateManager
{
    public class User
    {
        public User()
        {
            UserName = "admin";
            Roles = new List<Role>()
            {
                new Role {RoleID = 1, RoleName="admin" },
            };
        }
        public string UserName { get; set; }
        public UserProfile UserProfile { get; set; }
        public List<User_Role> UserRoles { get; set; }
        public List<Role> Roles { get; set; }
    }
}
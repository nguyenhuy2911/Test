
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Authorization_Authentication.AuthenticateManager
{
    public static class UserManager
    {

        private static readonly string aceptPass = "12345678";
        public static List<User> _listUser = new List<User>
        {
            new User
            {
                UserName  = "huy2911",
                UserProfile = new UserProfile
                {
                    Name = "Nguyễn Văn Huy",
                    Age = 26
                },
                Roles = new List<Role>
                {
                    new Role
                    {
                        RoleID = 1,
                        RoleName = "admin",
                        Functionalities = new List<Functionality>
                        {
                            new Functionality { ID= 1, Name="admin/product", Title="product"},
                            new Functionality { ID= 2, Name="admin/product/create", Title="create"},
                            new Functionality { ID= 3, Name="admin/product/update", Title="update"},
                            new Functionality { ID= 4, Name="admin/product/delete", Title="delete"},
                            new Functionality { ID= 5, Name="admin/category", Title="category"},
                            new Functionality { ID= 6, Name="admin/category/create", Title="create"},
                            new Functionality { ID= 7, Name="admin/category/update", Title="update"},
                            new Functionality { ID= 8, Name="admin/category/delete", Title="delete"},
                        },
                    }
                }
            },
            new User
            {
                UserName  = "thanh0215",
                UserProfile = new UserProfile
                {
                    Name = "Trần thị thanh thanh",
                    Age = 27
                },
                Roles = new List<Role>
                {
                    new Role
                    {
                        RoleID = 1,
                        RoleName = "content",
                        Functionalities = new List<Functionality>
                        {
                            new Functionality { ID= 5, Name="admin/category", Title="category"},
                            new Functionality { ID= 6, Name="admin/category/create", Title="create"},
                            new Functionality { ID= 7, Name="admin/category/update", Title="update"},
                            new Functionality { ID= 8, Name="admin/category/delete", Title="delete"},
                        }
                    }
                }
            },
        };

        public static bool ValidateUser(string userName, string password)
        {
            bool result = false;
            if (_listUser.Find(p => p.UserName.Equals(userName)) == null || !password.Equals(aceptPass))
            {
                return false;
            }
            // Create the authentication ticket with custom user data.
            var serializer = new JavaScriptSerializer();
            User _user = _listUser.Find(p => p.UserName.Equals(userName));
            string userData = serializer.Serialize(_user);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    userName,
                    DateTime.Now,
                    DateTime.Now.AddDays(30),
                    true,
                    userData,
                    FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            result = true;

            return result;
        }

        public static void Logoff()
        {
            // Delete the user details from cache.
            HttpContext.Current.Session.Abandon();

            // Delete the authentication ticket and sign out.
            FormsAuthentication.SignOut();

            // Clear authentication cookie.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static User GetUserFromCookie()
        {
            var _user = new User();
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                var ticketInfo = FormsAuthentication.Decrypt(cookie.Value);
                var deSerializer = new JavaScriptSerializer();
                _user = deSerializer.Deserialize<User>(ticketInfo.UserData);
            }
            else
                _user = null;
            return _user;
        }
    }
}

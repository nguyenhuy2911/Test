using Authorization_Authentication.AuthenticateManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Authorization_Authentication.Security
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public string FunctionName { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                                     filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
            }
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool _authorize = false;
            var user = UserManager.GetUserFromCookie();
            if (user != null && user.Roles.Any(p => p.Functionalities.Find(x => x.Name.Equals(FunctionName)) != null))
            {
                _authorize = true;
            }
            return _authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var user = UserManager.GetUserFromCookie();
            if (user != null)
                filterContext.Result = new RedirectResult("~/Admin/Home/NotAuthorRize");
            else
                filterContext.Result = new RedirectResult("~/Admin/Login");

        }
    }
}
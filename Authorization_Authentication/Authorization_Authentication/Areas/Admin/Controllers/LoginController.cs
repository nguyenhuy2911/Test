using Authorization_Authentication.Areas.Admin.Models;
using Authorization_Authentication.AuthenticateManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authorization_Authentication.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
           // UserManager.Logoff();
            var model = new LoginModel();
            return View(model);
        }


        [HttpPost]
        public ActionResult Login(LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (!UserManager.ValidateUser(model.UserName, model.PassWord))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            UserManager.Logoff();
            return RedirectToAction("Index");
        }
    }

}
using Authorization_Authentication.Areas.Admin.Models;
using Authorization_Authentication.AuthenticateManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authorization_Authentication.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var listUser = UserManager._listUser;
            
            var model = new HomeModel()
            {
                Users = listUser
            };
            return View(model);
        }

        public ActionResult NotAuthorRize()
        {
            return View();
        }
    }
}
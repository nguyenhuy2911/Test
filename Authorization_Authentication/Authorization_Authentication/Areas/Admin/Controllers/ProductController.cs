using Authorization_Authentication.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authorization_Authentication.Areas.Admin.Controllers
{
    [AuthorizeRoles(FunctionName = "admin/product")]
    public class ProductController : Controller
    {        

        public ActionResult Index()
        {
            return View();
        }
    }
}
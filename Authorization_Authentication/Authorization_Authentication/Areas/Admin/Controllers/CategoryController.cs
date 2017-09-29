using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authorization_Authentication.Security;
namespace Authorization_Authentication.Areas.Admin.Controllers
{
    [AuthorizeRoles(FunctionName = "admin/category")]
    public class CategoryController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}
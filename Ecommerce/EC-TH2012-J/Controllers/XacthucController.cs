﻿using Ecommerce.Web.Models;
using Ecommerce.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace  Ecommerce.Web.Controllers
{
    public class XacthucController : Controller
    {
        private static string Request_token;
        private static EcommerceModel_DbContext db = new EcommerceModel_DbContext();
        // GET: Xacthuc
        public ActionResult authenticate()
        {
            ViewBag.name = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public ActionResult authenticate(string btn)
        {
            try
            {
                var temp = db.Oauths.Where(m => m.Request_token == Request_token).FirstOrDefault();
                if (btn == "Không đồng ý")
                {
                    return Redirect(temp.Callback);
                }
                else
                {
                    string url = temp.Callback;
                    string ver = create_verifier(Request_token);
                    url += "?verifier_token=" + ver + "&request_token=" + Request_token;
                    temp.Verifier_token = ver;
                    db.SaveChanges();
                    return Redirect(url);
                }
            }
            catch (Exception e) { return RedirectToAction("Index","Home"); }
        }

        private string create_verifier(string Request_token)
        {
            Random rand = new Random();
            string username = User.Identity.Name;
            string verifier = Request_token;
            for(int i = 0 ; i < username.Length ; i++)
            {
                int index = rand.Next() % username.Length;
                verifier += username[index];
            }
            for(int i = 0 ; i < 5 ; i++)
            {
                int index = rand.Next() % 10;
                verifier += index.ToString();
            }
            
            return verifier;
        }
        public ActionResult Kiemtra(string id)
        {
            Request_token = id;
            db = new EcommerceModel_DbContext();
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("authenticate", "Xacthuc");
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("authenticate","Xacthuc") });
            }
        }
    }
}
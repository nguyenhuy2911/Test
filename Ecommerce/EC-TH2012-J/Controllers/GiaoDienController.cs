﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Domain.Model;
using Ecommerce.Web.Models;

namespace  Ecommerce.Web.Controllers
{

    public class GiaoDienController : Controller
    {
        //
        // GET: /GiaoDien/
        public ActionResult Header()
        {
            GiaoDienModel dd = new GiaoDienModel();
            List<GiaoDien> model = dd.GetDD().ToList();
            return View(model);
        }

        [AuthLog(Roles = "Quản trị viên,Nhân viên")]
        public ActionResult General()
        {
            GiaoDienModel dd = new GiaoDienModel();
            List<GiaoDien> model = dd.GetDD().ToList();
            return View(model);
        }

        public ActionResult SlideShowView()
        {
            KhuyenMaiModel km = new KhuyenMaiModel();
            var model = km.TimKhuyenMai(null, null, null).Where(m => m.NgayBatDau <= DateTime.Today && m.NgayKetThuc >= DateTime.Today);
            return PartialView("SlideShowView", model);
        }

        public ActionResult SlideShowSetting()
        {
            GiaoDienModel gd = new GiaoDienModel();
            List<Link> linklist = gd.GetSlideShow().ToList();
            return View(linklist);
        }

        public ActionResult SlideShow()
        {
            Link link = new Link();
            link.Group = "SlideShow";
            return View(link);
        }

    }
}
﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAddBL(p);
            return RedirectToAction("Index");
        }
    }
}
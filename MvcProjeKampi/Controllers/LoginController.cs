using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminLoginManager lm = new AdminLoginManager(new EfAdminLoginDal());
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterLoginDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            //Context c = new Context();
            //var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);

            //if (adminUserInfo != null)
            //{
            //    FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
            //    Session["AdminUserName"] = adminUserInfo.AdminUserName;
            //    return RedirectToAction("Index", "AdminCategory");
            //}

            //else
            //{
            //    return RedirectToAction("Index");
            //}

            if (lm.IsAdmin(p.AdminUserName, p.AdminPassword))
            {
                FormsAuthentication.SetAuthCookie(p.AdminUserName, false);
                Session["AdminUserName"] = p.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }

            //ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
            TempData["Message"] = "Kullanıcı adı veya parola yanlış.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            if (wlm.IsUser(p.WriterMail, p.WriterPassword))
            {
                FormsAuthentication.SetAuthCookie(p.WriterMail, false);
                Session["WriterMail"] = p.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }

            //ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
            TempData["Message"] = "Kullanıcı adı veya parola yanlış.";
            return RedirectToAction("WriterLogin");
        }
    }
}
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messageListInbox = mm.GetListInbox();
            return View(messageListInbox);
        }

        public ActionResult Sendbox()
        {
            var messageListSendbox = mm.GetListSendbox();
            return View(messageListSendbox);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewDraft()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewDraft(Message p)
        {
            //p.IsDraft = true;
            //mm.MessageAddBL(p);

            //return RedirectToAction("Index");

            //MessageValidator messageValidator = new MessageValidator();
            //ValidationResult results = messageValidator.Validate(message);
            //HttpUtility utility = new HttpUtility();



            //if (results.IsValid)
            //{
            //    if (buttons == "send")
            //    {
            //        message.SenderMail = "admin@gmail.com";
            //        message.isDraft = false;
            //        message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //        mm.MessageAddBl(message);
            //        return RedirectToAction("Sendbox");

            //    }
            //    else if (buttons == "draft")
            //    {
            //        message.SenderMail = "admin@gmail.com";
            //        message.isDraft = true;
            //        message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            //        //MvcHtmlString data = MvcHtmlString.Create( message.MessageContent);

            //        //message.MessageContent = data.ToString();


            //        string data = Server.HtmlEncode(message.MessageContent);
            //        message.MessageContent = data;


            //        mm.MessageAddBl(message);
            //        return RedirectToAction("DraftList");

            //    }
            //}

            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
        }
    }
}
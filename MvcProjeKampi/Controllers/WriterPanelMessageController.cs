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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messageListInbox = mm.GetListInbox();

            var messageList = mm.GetListInbox();
            ViewBag.receiver = messageList.Count();

            return View(messageListInbox);
        }

        public ActionResult Sendbox()
        {
            var messageListSendbox = mm.GetListSendbox();
            return View(messageListSendbox);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);

            if (values.IsRead == false)
                values.IsRead = true;

            mm.MessageUpdateBL(values);

            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message, string buttons)
        {
            ValidationResult results = messageValidator.Validate(message);
            //HttpUtility utility = new HttpUtility();

            if (results.IsValid)
            {
                if (buttons == "send")
                {
                    message.SenderMail = "orhanpamuk@gmail.com";
                    message.IsDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAddBL(message);
                    return RedirectToAction("Sendbox");

                }
                else if (buttons == "draft")
                {
                    message.SenderMail = "orhanpamuk@gmail.com";
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                    //MvcHtmlString data = MvcHtmlString.Create( message.MessageContent);

                    //message.MessageContent = data.ToString();

                    string data = Server.HtmlEncode(message.MessageContent);
                    message.MessageContent = data;

                    mm.MessageAddBL(message);
                    //return RedirectToAction("DraftList");
                    return RedirectToAction("DraftBox");
                }
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
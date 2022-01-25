using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult MessageListMenu()
        {
            var contactValues = cm.GetList();
            ViewBag.contact = contactValues.Count();

            //var messageList = mm.GetListInbox();
            //ViewBag.receiver = messageList.Count();

            ViewBag.unreadMessages = mm.GetUnreadMessagesInbox();

            var messagecount = mm.GetListSendbox();
            ViewBag.sendvalue = messagecount.Count();

            var draftCount = mm.GetListDrafts();
            ViewBag.draft = draftCount.Count();

            //var draftValue = mm.GetAllDraft();
            //ViewBag.draftValue = draftValue.Count();

            //var unReadValue = mm.UnReadList().Count();
            //ViewBag.unReadValue = unReadValue;

            //var readValue = mm.ReadList().Count();
            //ViewBag.readValue = readValue;


            return PartialView();
        }
    }
}
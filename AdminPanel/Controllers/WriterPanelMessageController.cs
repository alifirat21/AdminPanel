using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        public PartialViewResult MessageListPartial()
        {
            return PartialView();
        }
        public ActionResult Inbox()
        {
            
            string p = Session["WriterMail"].ToString();
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);

            
        }
        public ActionResult Sendbox()
        {
            string p = Session["WriterMail"].ToString();
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }

        public ActionResult SendboxDetail(int id)
        {
            var sendboxDetail = mm.GetByID(id);
            return View(sendboxDetail);
        }
        public ActionResult InboxDetail(int id)
        {
            var inboxDetail = mm.GetByID(id);
            return View(inboxDetail);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = Session["WriterMail"].ToString();
            p.SenderMail = sender;
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.MessageAdd(p);
            return RedirectToAction("Sendbox");
        }   

    }
}
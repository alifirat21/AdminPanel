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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Inbox(string p)
        {
            var messageListBox = mm.GetListInbox(p);
            return View(messageListBox);
        }
        public ActionResult Sendbox(string p)
        {
            var messageListSend = mm.GetListSendbox(p);
            return View(messageListSend);
        }
        
        public ActionResult InboxDetail(int id)
        {
            var inboxDetail = mm.GetByID(id);
            return View(inboxDetail);
        }
        public ActionResult SendboxDetail(int id)
        {
            var SendboxDetail = mm.GetByID(id);
            return View(SendboxDetail);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.MessageAdd(p);
            return RedirectToAction("Sendbox");
        }
        
    }
}
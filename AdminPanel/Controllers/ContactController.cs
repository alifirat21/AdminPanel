using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());

        public ActionResult Index()
        {
            var contactValue = cm.GetContactList();
            return View(contactValue);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValue = cm.GetByID(id);
            return View(contactValue);
        }
        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}
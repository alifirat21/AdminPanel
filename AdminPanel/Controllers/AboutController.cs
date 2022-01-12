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
    public class AboutController : Controller
    {
        // GET: Abput
        AboutManager abm = new AboutManager(new EfAboutDal()); 
        public ActionResult Index()
        {
            var aboutValue = abm.GetAboutList();
            return View(aboutValue);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var aboutValue = abm.GetByID(id);
            abm.AboutDelete(aboutValue);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        
    }
}
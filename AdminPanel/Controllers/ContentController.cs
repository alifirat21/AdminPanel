using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {
            if (p == null)
            {
                var contentValue = cm.GetContentList();
                return View(contentValue);
            }
            var conentValue = cm.GetContentListFİnd(p);
            return View(conentValue);
        }
         public ActionResult ContentByHeading(int id)
        {
            var contentValue = cm.GetListByHeadingID(id);
            return View(contentValue);
        }
    }
}
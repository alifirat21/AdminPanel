using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class WriterPanelContentController : Controller
    {
        Context c = new Context();
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult MyContent(string p)
        {
            p = Session["WriterMail"].ToString();
            //BU YÖNTEM Bİ AŞAGIDAKİNİN KISA YOLU
            //var writerIdInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p).WriterID;
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValue = cm.GetListByWriter(writerIdInfo);
            //ViewBag.v = writerIdInfo;
            return View(contentValue);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = Session["WriterMail"].ToString();
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerIdInfo;
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            
            cm.AddContent(p);
            return RedirectToAction("MyContent");
        }
    }
}
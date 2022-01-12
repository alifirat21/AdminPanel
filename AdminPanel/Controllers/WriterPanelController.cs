using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Newtonsoft.Json;
using AdminPanel.Models;

namespace AdminPanel.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        Context c = new Context();
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = Session["WriterMail"].ToString();
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            wm.WriterUpdate(p);
            return RedirectToAction("WriterProfile");
        }
        public ActionResult MyHeading(string p)
        {
            p = Session["WriterMail"].ToString();
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.value = hm.GetListByWriter(writerIdInfo);
            return View();
        }
        //[HttpPost]
        //public JsonResult Getup(int id) 
        //{
        //    var model = c.Headings.FirstOrDefault(x=>x.HeadingID == id);
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}


        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public JsonResult GetStudentList()
        //{
        //    //Pass The All Student Record From Controller To View For Show The All Data For User
        //    List<Heading> StuList = c.Headings.Select(x => new Heading
        //    {
        //        HeadingID = x.HeadingID,
        //        HeadingName = x.HeadingName
        //    }).ToList();
        //    return Json(StuList, JsonRequestBehavior.AllowGet);
        //}


        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writerMailInfo = Session["WriterMail"].ToString();
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterID).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerIdInfo;
            p.HeadingSatatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }
        public JsonResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            headingValue.HeadingSatatus = false;
            hm.HeadingDelete(headingValue);
            return Json(new { status = "Success" });
        }
      
        [HttpGet]
        public JsonResult UpdateHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            var headingValue = hm.GetByID(id);
            
            //ViewModel
            HeadingVM vm = new HeadingVM();
            vm.heading = headingValue;
            
            string value = "";
            value = JsonConvert.SerializeObject(headingValue, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value,JsonRequestBehavior.AllowGet);
            //return PartialView("EditPartial","WriterPanel");
        }
        [HttpPost]
        public ActionResult UpdateHeading(HeadingVM p, Heading heading)
        {
            //Heading hd = c.Headings.SingleOrDefault(x => x.HeadingID == p.heading.HeadingID);

            


            //heading.HeadingID = p.heading.HeadingID;
            //heading.HeadingName = p.heading.HeadingName;
            //heading.HeadingSatatus = p.heading.HeadingSatatus;
            //heading.HeadingDate = p.heading.HeadingDate;
            //heading.CategoryID = p.heading.CategoryID;
            //heading.WriterID = p.heading.WriterID;

            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public PartialViewResult EditPartial()
        {
            return PartialView();
        }
        public ActionResult AllHeading(int page = 1)
        {
            var headingValue = hm.GetHeadingList().ToPagedList(page, 4);
            return View(headingValue);
        }
    }
}
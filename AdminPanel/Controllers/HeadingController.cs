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

namespace AdminPanel.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValue = hm.GetHeadingList();
            return View(headingValue);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in wm.GetWriterList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;

            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            HeadingValidator validationRules = new HeadingValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.HeadingAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetCategoryList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.vbCategory = valueCategory;
            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            headingValue.HeadingSatatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}
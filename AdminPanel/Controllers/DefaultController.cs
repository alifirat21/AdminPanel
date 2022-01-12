using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headingValue = hm.GetHeadingList();
            return View(headingValue);
        }
        public PartialViewResult Index(int id = 0)
        {
            var contentVaule = cm.GetListByHeadingID(id);
            return PartialView(contentVaule);
        }

    }
}
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminPanel.Controllers
{
    
    [AllowAnonymous]
    public class LoginController : Controller
    {
        int sayac = 0;

        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        AdminLoginManager alm = new AdminLoginManager(new EfAdminDal());
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {

            //Context c = new Context();
            //var adminUserİnfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            var adminuserInfo = alm.GetAdminLogin(p.AdminUserName,p.AdminPassword);
            if (adminuserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserInfo.AdminUserName,false);
                Session["AdminUserName"] = adminuserInfo.AdminUserName; 
                return RedirectToAction("Index", "Category");

            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin p)
        {
            SignupValidator signupValidator = new SignupValidator();
            ValidationResult result = signupValidator.Validate(p);
            p.AdminRole = "B";
            p.AdminPassword = Sifrele.MD5Olustur(p.AdminPassword);
            if (result.IsValid)
            {
                alm.AdminAdd(p);
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
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public JsonResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            bool isLogged = true;
            string sifre = Sifrele.MD5Olustur(p.WriterPassword);
            var writerUserInfo = wlm.GetWriterLogin(p.WriterMail, sifre);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;

                //if (writerUserInfo.WriterMail == p.WriterMail)
                //{
                //    isLogged = true;

                //}
                //else
                //{
                //    isLogged = false;
                //}

                //return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
               
                isLogged = false;
               
            }
            return Json(isLogged, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterAdd(Writer p)
        {
            p.WriterStatus = true;
            p.WriterPassword = Sifrele.MD5Olustur(p.WriterPassword);
            wlm.WriterAdd(p);
            return RedirectToAction("WriterLogin");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("WriterLogin", "Login");
        }
        public ActionResult LogOutAdmin()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
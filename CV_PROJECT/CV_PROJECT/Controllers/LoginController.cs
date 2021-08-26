using CV_PROJECT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CV_PROJECT.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TBL_ADMIN p)
        {
            DbCvEntities db = new DbCvEntities();
            var kullaniciBilgi = db.TBL_ADMIN.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.SIFRE == p.SIFRE);
            if (kullaniciBilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciBilgi.KULLANICIADI, false);
                Session["KULLANICIADI"] = kullaniciBilgi.KULLANICIADI.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}
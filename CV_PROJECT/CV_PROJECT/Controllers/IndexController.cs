using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_PROJECT.Models.Entity;
namespace CV_PROJECT.Controllers
{
    [AllowAnonymous]
    public class IndexController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        // GET: Index
        public ActionResult Index()
        {
            var deger = db.TBL_HAKKIMDA.ToList();
            return View(deger);
        }

        public ActionResult SosyalMedya()
        {
            var deger = db.TBL_SOSYALMEDYA.Where(x=>x.DURUM==true).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Deneyim()
        {
            var deger = db.TBL_DENEYIM.ToList();
            return PartialView(deger);
        }

        public PartialViewResult Egitim()
        {
            var deger = db.TBL_EGITIM.ToList();
            return PartialView(deger);
        }

        public PartialViewResult Yetenek()
        {
            var deger = db.TBL_YETENEK.ToList();
            return PartialView(deger);
        }
        public PartialViewResult Hobi()
        {
            var deger = db.TBL_HOBI.ToList();
            return PartialView(deger);
        }

        public PartialViewResult Sertifika()
        {
            var deger = db.TBL_SERTIFIKA.ToList();
            return PartialView(deger);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(TBL_ILETISIM t)
        {
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_ILETISIM.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}
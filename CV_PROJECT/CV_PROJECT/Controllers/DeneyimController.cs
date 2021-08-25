using CV_PROJECT.Models.Entity;
using CV_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_PROJECT.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TBL_DENEYIM p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

       public ActionResult DeneyimSil(int id)
        {
            TBL_DENEYIM t = repo.Find(x=>x.ID==id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBL_DENEYIM t = repo.Find(x => x.ID == id);
            return View(t);

        }

        [HttpPost]
        public ActionResult DeneyimGetir(TBL_DENEYIM p)
        {
            TBL_DENEYIM t = repo.Find(x => x.ID == p.ID);
            t.BASLIK = p.BASLIK;
            t.ALTBASLIK = p.ALTBASLIK;
            t.ACIKLAMA = p.ACIKLAMA;
            t.TARIH = p.TARIH;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
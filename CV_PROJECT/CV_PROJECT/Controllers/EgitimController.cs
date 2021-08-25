using CV_PROJECT.Repositories;
using CV_PROJECT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_PROJECT.Controllers
{
    public class EgitimController : Controller
    {
        EgitimRepository repo = new EgitimRepository();
        // GET: Egitim
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TBL_EGITIM p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            TBL_EGITIM t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TBL_EGITIM t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimGetir(TBL_EGITIM p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            TBL_EGITIM t = repo.Find(x => x.ID == p.ID);
            t.BASLIK = p.BASLIK;
            t.ALTBASLIK1 = p.ALTBASLIK1;
            t.ALTBASLIK2 = p.ALTBASLIK2;
            t.GNO = p.GNO;
            t.TARIH = p.TARIH;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
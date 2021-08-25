using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_PROJECT.Models.Entity;
using CV_PROJECT.Repositories;
namespace CV_PROJECT.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikaRepository repo = new SertifikaRepository();
        // GET: Sertifika
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TBL_SERTIFIKA p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            TBL_SERTIFIKA t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            TBL_SERTIFIKA t = repo.Find(x => x.ID == id);
            return View(t);

        }

        [HttpPost]
        public ActionResult SertifikaGetir(TBL_SERTIFIKA p)
        {
            TBL_SERTIFIKA t = repo.Find(x => x.ID == p.ID);
            t.ACIKLAMA = p.ACIKLAMA;
            t.TARIH = p.TARIH;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
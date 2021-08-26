using CV_PROJECT.Models.Entity;
using CV_PROJECT.Repositories;
using CV_PROJECT.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_PROJECT.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TBL_SOSYALMEDYA> repo = new GenericRepository<TBL_SOSYALMEDYA>();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SosyalMedyaEkle(TBL_SOSYALMEDYA p)
        {
            p.DURUM = true;
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            var deger = repo.Find(x => x.ID == id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult SosyalMedyaGetir(TBL_SOSYALMEDYA p)
        {
            var deger = repo.Find(x => x.ID == p.ID);
            deger.AD = p.AD;
            deger.LINK = p.LINK;
            deger.IKON = p.IKON;
            deger.DURUM =true;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }

        public ActionResult SosyalMedyaSil(int id)
        {
            var durum = repo.Find(x => x.ID == id);
            durum.DURUM = false;
            repo.TUpdate(durum);
            return RedirectToAction("Index");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_PROJECT.Models.Entity;
using CV_PROJECT.Repostories;

namespace CV_PROJECT.Controllers
{
    public class YetenekController : Controller
    {

        GenericRepository<TBL_YETENEK> repo = new GenericRepository<TBL_YETENEK>();
        public ActionResult Index()
        {
            var yetenek = repo.List();
            return View(yetenek);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(TBL_YETENEK p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            TBL_YETENEK t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult YetenekGetir(TBL_YETENEK y)
        {
            TBL_YETENEK t = repo.Find(x => x.ID == y.ID);
            t.YETENEK = y.YETENEK;
            t.ORAN = y.ORAN;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
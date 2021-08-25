using CV_PROJECT.Models.Entity;
using CV_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_PROJECT.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        HobiRepository repo = new HobiRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult HobiGetir(int id)
        {
            TBL_HOBI t = repo.Find(x => x.ID == id);
            return View(t);

        }

        [HttpPost]
        public ActionResult HobiGetir(TBL_HOBI p)
        {
            TBL_HOBI t = repo.Find(x => x.ID == p.ID);
            t.ACIKLAMA1 = p.ACIKLAMA1;
            t.ACIKLAMA2 = p.ACIKLAMA2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
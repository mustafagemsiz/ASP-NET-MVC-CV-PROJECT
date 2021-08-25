using CV_PROJECT.Models.Entity;
using CV_PROJECT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_PROJECT.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        IletisimRepository repo = new IletisimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        public ActionResult IletisimSil(int id)
        {
            TBL_ILETISIM t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}
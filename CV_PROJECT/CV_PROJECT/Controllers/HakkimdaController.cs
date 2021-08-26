using CV_PROJECT.Models.Entity;
using CV_PROJECT.Repostories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_PROJECT.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbCvEntities db = new DbCvEntities();
        GenericRepository<TBL_HAKKIMDA> repo = new GenericRepository<TBL_HAKKIMDA>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(TBL_HAKKIMDA p)
        {

            if (Request.Files.Count > 0)

            {

                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);


                string yol = "~/Image/" + dosyaadi ;

                Request.Files[0].SaveAs(Server.MapPath(yol));

                p.RESIM = "/Image/" + dosyaadi ;


            }

            var t = repo.Find(x => x.ID == 1);
            t.AD = p.AD;
            t.SOYAD = p.SOYAD;
            t.ADRES = p.ADRES;
            t.MAIL = p.MAIL;
            t.TELEFON = p.TELEFON;
            t.ACIKLAMA = p.ACIKLAMA;
            t.RESIM = p.RESIM;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
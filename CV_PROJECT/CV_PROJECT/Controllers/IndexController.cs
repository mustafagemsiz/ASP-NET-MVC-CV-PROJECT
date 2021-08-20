using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_PROJECT.Models.Entity;
namespace CV_PROJECT.Controllers
{
    public class IndexController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        // GET: Index
        public ActionResult Index()
        {
            var deger = db.TBL_HAKKIMDA.ToList();

            return View(deger);
        }
    }
}
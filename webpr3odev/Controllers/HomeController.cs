using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webpr3odev.Controllers
{
    
    public class HomeController : Controller
    {
        oktDBEntities1 db = new oktDBEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult _KonuView()
        {
            var liste = db.Konular.Where(x => x.Btarih < DateTime.Now && x.Bitarih > DateTime.Now).OrderByDescending(x => x.ID);
            return View(liste);
        }
    }
}
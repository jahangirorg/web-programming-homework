using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webpr3odev.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/Home
        [Authorize(Roles = "Yonetici")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
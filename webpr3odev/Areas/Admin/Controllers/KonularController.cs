
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpr3odev.Areas.Admin.Models;

namespace webpr3odev.Areas.Admin.Controllers
{
    [Authorize(Roles = "Yonetici")]
    public class KonularController : Controller
    {
        oktDBEntities1 db = new oktDBEntities1();
        // GET: Admin/Konular
        public ActionResult Index()
        {
            var model = db.Konular.OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }

        const string imageFolderPath = "/Content/images/";
        public ActionResult AddKonular(KonularModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                //Dosya Kaydet
                if (model.Resim != null && model.Resim.ContentLength > 0)
                {
                    fileName = model.Resim.FileName;
                    var path = Path.Combine(Server.MapPath("~" + imageFolderPath), fileName);
                    model.Resim.SaveAs(path);
                }
                //EF Nesnesi Olustur
                Konular konular = new Konular();
                konular.Btarih = model.Btarih;
                konular.Bitarih = model.Bitarih;
                konular.KonuBaslik = model.KonuBaslik;
                konular.ResimUzanti = imageFolderPath + fileName;

                db.Konular.Add(konular);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Konular.Find(id);
            //db.Konular.FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Konular model)
        {
            if (ModelState.IsValid)
            {
                db.Konular.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Konular.Find(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            var model = db.Konular.Find(id);
            db.Konular.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

  
}
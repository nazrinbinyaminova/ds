using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoguishTemplate.Models;

namespace VoguishTemplate.Controllers
{
    public class CategoryController : Controller
    {
        private VoguishEntities db = new VoguishEntities();
        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cat)
        {
            db.Categories.Add(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Category cat = db.Categories.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            Category cat = db.Categories.Find(category.Id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Category cat = db.Categories.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category cat = db.Categories.Find(category.Id);
            cat.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
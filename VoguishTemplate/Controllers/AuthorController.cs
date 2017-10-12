using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoguishTemplate.Models;

namespace VoguishTemplate.Controllers
{
    public class AuthorController : Controller
    {
        private VoguishEntities db = new VoguishEntities();
        // GET: Author
        public ActionResult Index()
        {
            return View(db.Authors.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Author aut = db.Authors.Find(Id);
            return View(aut);
        }

        [HttpPost]
        public ActionResult Delete(Author author)
        {
            Author aut = db.Authors.Find(author.Id);
            db.Authors.Remove(aut);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Author aut = db.Authors.Find(Id);
            return View(aut);
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            Author aut = db.Authors.Find(author.Id);
            aut.Name = author.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
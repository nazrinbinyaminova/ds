using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoguishTemplate.Models;

namespace VoguishTemplate.Controllers
{
    public class LinkController : Controller
    {
        private VoguishEntities db = new VoguishEntities();
        // GET: Link
        public ActionResult Index()
        {
            return View(db.Links.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Link links)
        {
            db.Links.Add(links);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Link links = db.Links.Find(Id);
            return View(links);
        }

        [HttpPost]
        public ActionResult Delete(Link links)
        {
            Link li = db.Links.Find(links.Id);
            db.Links.Remove(li);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Link links = db.Links.Find(Id);
            return View(links);
        }

        [HttpPost]
        public ActionResult Edit(Link links)
        {
            Link li = db.Links.Find(links.Id);
            li.Name = links.Name;
            li.Url = links.Url;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
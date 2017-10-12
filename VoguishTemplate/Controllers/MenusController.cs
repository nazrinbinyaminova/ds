using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoguishTemplate.Models;

namespace VoguishTemplate.Controllers
{
    public class MenusController : Controller
    {
        private VoguishEntities db = new VoguishEntities();
        public int Id;
        // GET: Menus
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(db.Links.ToList());
        }

        [HttpPost]
        public ActionResult Create(string Name, string Url, string Link)
        {
            Menu menus = new Menu();
            var LinkList = db.Links.ToList();
            var Men = (from menu in LinkList
                       where menu.Name == Link
                       select new { Id = menu.Id }).Single();
            menus.Name = Name;
            menus.Url = Url;
            menus.Link_Id = Men.Id;
            db.Menus.Add(menus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Menu menu = db.Menus.Find(Id);
            return View(menu);
        }

        [HttpPost]
        public ActionResult Delete(Menu m)
        {
            Menu menus = db.Menus.Find(m.Id);
            db.Menus.Remove(menus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewBag.links = db.Links.ToList();
            Menu menu = db.Menus.Find(Id);
            return View(menu);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Link_Id")] Menu m, string Link_Id)
        {
            Menu menus = db.Menus.Find(m.Id);
            menus.Name = m.Name;
            menus.Url = m.Url;
            menus.Link_Id = Convert.ToInt32(Link_Id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
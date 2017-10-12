using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoguishTemplate.Models;
using VoguishTemplate.View_Models;

namespace VoguishTemplate.Controllers
{
    public class HomeController : Controller
    {
        private VoguishEntities db = new VoguishEntities();
        ViewModel viewMod = new ViewModel();

        public ActionResult Index()
        {
            viewMod.Authors = db.Authors.ToList();
            viewMod.Categories = db.Categories.ToList();
            viewMod.Filesses = db.Filesses.ToList();
            viewMod.Links = db.Links.ToList();
            viewMod.Menus = db.Menus.ToList();
            viewMod.Newses = db.News.ToList();
            return View(viewMod);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoguishTemplate.Models;

namespace VoguishTemplate.Controllers
{
    public class MenuController : Controller
    {
        private VoguishEntities db = new VoguishEntities();
        // GET: Menu
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Menu menuu)
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoguishTemplate.Models;
using VoguishTemplate.View_Models;

namespace VoguishTemplate.Controllers
{
    public class NewsController : Controller
    {
        private VoguishEntities db = new VoguishEntities();
        // GET: News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        public ActionResult Create()
        {
            ViewModel view = new ViewModel();
            view.Filesses = db.Filesses.ToList();
            view.Categories = db.Categories.ToList();
            view.Authors = db.Authors.ToList();
            return View(view);
        }

        [HttpPost]
        public ActionResult Create(string Title, string Text, string File_Name, string Cat_Name, string Author_Name, string Add_Date, string View_Count)
        {
            
            News news = new News();
            var AuthorList = db.Authors.ToList();
            var Aut = (from aut in AuthorList
                          where aut.Name == Author_Name
                          select new { Id=aut.Id}).Single();
            var CatList = db.Categories.ToList();
            var Cat = (from cat in CatList
                          where cat.Name == Cat_Name
                          select new { Id= cat.Id }).Single();
            var FileList = db.Filesses.ToList();
            var File = (from files in FileList
                           where files.Name == File_Name
                           select new { Id= files.Id }).Single();
            news.Title = Title;
            news.Text = Text;
            news.Filess_Id =File.Id;
            news.Cat_Id = Cat.Id;
            news.Author_Id = Aut.Id;
            news.Add_Date = Convert.ToDateTime(Add_Date);
            news.View_Count = Convert.ToInt32(View_Count);
            db.News.Add(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            News news = db.News.Find(Id);
            return View(news);
        }

        [HttpPost]
        public ActionResult Delete(News n)
        {
            News news = db.News.Find(n.Id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewBag.Files = db.Filesses.ToList();
            ViewBag.Cat = db.Categories.ToList();
            ViewBag.Author = db.Authors.ToList();
            News news = db.News.Find(Id);
            return View(news);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude ="Filess_Id, Cat_Id, Author_Id")] News n, string Filess_Id, string Cat_Id, string Author_Id)
        {
            News news = db.News.Find(n.Id);
            news.Title = n.Title;
            news.Text = n.Text;
            news.Filess_Id = Convert.ToInt32(Filess_Id);
            news.Cat_Id = Convert.ToInt32(Cat_Id);
            news.Author_Id = Convert.ToInt32(Author_Id);
            news.Add_Date = n.Add_Date;
            news.View_Count = n.View_Count;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoguishTemplate.Models;
using System.IO;

namespace VoguishTemplate.Controllers
{
    public class FilessController : Controller
    {
        private VoguishEntities db = new VoguishEntities();
        public string FileName;
        public string FilePath;
        public int FileSize;
        public string FileExtention;
        // GET: File
        public ActionResult Index()
        {
            return View(db.Filesses.ToList());
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase Image)
        {
            if (Image.ContentLength > 0) 
            {
                FileName = Path.GetFileName(Image.FileName);
                FilePath = Path.Combine(Server.MapPath("~/Uploads/"), FileName);
                FileExtention = Path.GetExtension(FileName);
                FileSize = Image.ContentLength;
                Image.SaveAs(FilePath);
            }
            Filess File = new Filess();
            File.Name = FileName;
            File.Extention = FileExtention;
            File.Path = FilePath;
            File.Size = FileSize;
            db.Filesses.Add(File);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Filess file = db.Filesses.Find(Id);
            return View(file);
        }

        [HttpPost]
        public ActionResult Delete(Filess file)
        {
            Filess files = db.Filesses.Find(file.Id);
            db.Filesses.Remove(files);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
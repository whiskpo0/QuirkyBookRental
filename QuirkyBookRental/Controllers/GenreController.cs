using QuirkyBookRental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuirkyBookRental.Controllers
{
    public class GenreController : Controller
    {
        private ApplicationDbContext db;

        public GenreController()
        {
            db = new ApplicationDbContext(); 
        }

        // GET: Genre
        public ActionResult Index()
        {
            return View(db.Genre.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if(ModelState.IsValid)
            {
                db.Genre.Add(genre);
                db.SaveChanges(); 
            }
            
            return RedirectToAction("Index");

        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }

            Genre genre = db.Genre.Find(id); 
            if( genre == null)
            {
                return HttpNotFound(); 
            }

            return View(genre);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genre.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if(ModelState.IsValid)
            {

                // Faster and better way in updating items in the database.
                //var GenreInDb = db.Genre.FirstOrDefault(g => g.Id.Equals(genre.Id));
                //GenreInDb.Name = genre.Name;

                db.Entry(genre).State = EntityState.Modified;  // this is a heavy call do not use
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genre.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Genre genre = db.Genre.Find(id);
            db.Genre.Remove(genre);
            db.SaveChanges();
            return RedirectToAction("Index");          
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose(); 
        }
    }
}
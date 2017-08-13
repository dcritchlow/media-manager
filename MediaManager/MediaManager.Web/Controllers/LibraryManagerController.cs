using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MediaManager.Web.Models;

namespace MediaManager.Web.Controllers
{
    
    public class LibraryManagerController : Controller
    {
        MediaManagerEntities Db = new MediaManagerEntities();

        public ActionResult Index()
        {

            return View(Db.Movies);
        }

        public ActionResult Create()
        {
            ViewBag.MPAARatingId = new SelectList(Db.MPAARatings, "MPAARatingId", "Rating");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie myMovie)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(myMovie).State = EntityState.Added;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MPAARatingId = new SelectList(Db.MPAARatings, "MPAARatingId", "Rating");
            return View(myMovie);
        }
    }
}
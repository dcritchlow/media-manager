using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediaManager.Web.Models;

namespace MediaManager.Web.Controllers
{
    public class MPAARatingsController : Controller
    {
        private MediaManagerEntities db = new MediaManagerEntities();

        // GET: MPAARatings
        public ActionResult Index()
        {
            return View(db.MPAARatings.ToList());
        }

        // GET: MPAARatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPAARating mPAARating = db.MPAARatings.Find(id);
            if (mPAARating == null)
            {
                return HttpNotFound();
            }
            return View(mPAARating);
        }

        // GET: MPAARatings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MPAARatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MPAARatingId,Rating")] MPAARating mPAARating)
        {
            if (ModelState.IsValid)
            {
                db.MPAARatings.Add(mPAARating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mPAARating);
        }

        // GET: MPAARatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPAARating mPAARating = db.MPAARatings.Find(id);
            if (mPAARating == null)
            {
                return HttpNotFound();
            }
            return View(mPAARating);
        }

        // POST: MPAARatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MPAARatingId,Rating")] MPAARating mPAARating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mPAARating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mPAARating);
        }

        // GET: MPAARatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MPAARating mPAARating = db.MPAARatings.Find(id);
            if (mPAARating == null)
            {
                return HttpNotFound();
            }
            return View(mPAARating);
        }

        // POST: MPAARatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MPAARating mPAARating = db.MPAARatings.Find(id);
            db.MPAARatings.Remove(mPAARating);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

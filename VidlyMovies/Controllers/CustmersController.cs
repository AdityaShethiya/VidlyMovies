using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VidlyMovies.Models;

namespace VidlyMovies.Controllers
{
    public class CustmersController : Controller
    {
        private MoviesEntities db = new MoviesEntities();

        // GET: Custmers
        public ActionResult Index()
        {
          
            return View(db.Custmers.ToList());
        }

        // GET: Custmers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custmer custmer = db.Custmers.Find(id);
            if (custmer == null)
            {
                return HttpNotFound();
            }
            return View(custmer);
        }

        // GET: Custmers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Custmers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustmerId,CustmerName,MembershipTypeId,DateOfBirth")] Custmer custmer)
        {
            if (ModelState.IsValid)
            {
                db.Custmers.Add(custmer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(custmer);
        }

        // GET: Custmers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custmer custmer = db.Custmers.Find(id);
            if (custmer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SignupFree = new SelectList(db.MembershipTypes, "SignupFree", "SignupFree");
            return View(custmer);
        }

        // POST: Custmers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustmerId,CustmerName,MembershipTypeId,DateOfBirth")] Custmer custmer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custmer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(custmer);
        }

        // GET: Custmers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custmer custmer = db.Custmers.Find(id);
            if (custmer == null)
            {
                return HttpNotFound();
            }
            return View(custmer);
        }

        // POST: Custmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Custmer custmer = db.Custmers.Find(id);
            db.Custmers.Remove(custmer);
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

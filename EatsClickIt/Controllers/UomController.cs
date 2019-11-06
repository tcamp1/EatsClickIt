using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EatsClickIt.Models;

namespace EatsClickIt.Controllers
{
    public class UomController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Uom
        public ActionResult Index()
        {
            return View(db.Uoms.ToList());
        }

        // GET: Uom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uom uom = db.Uoms.Find(id);
            if (uom == null)
            {
                return HttpNotFound();
            }
            return View(uom);
        }

        // GET: Uom/Create
        public ActionResult Create()
        {
			Uom uom = new Uom();
            return View(uom);
        }

        // POST: Uom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UomId,UofM,Active,Created")] Uom uom)
        {
            if (ModelState.IsValid)
            {
                uom.Created = DateTime.Now;
				db.Uoms.Add(uom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uom);
        }

        // GET: Uom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uom uom = db.Uoms.Find(id);
            if (uom == null)
            {
                return HttpNotFound();
            }
            return View(uom);
        }

        // POST: Uom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UomId,UofM,Active,Created")] Uom uom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uom);
        }

        // GET: Uom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uom uom = db.Uoms.Find(id);
            if (uom == null)
            {
                return HttpNotFound();
            }
            return View(uom);
        }

        // POST: Uom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uom uom = db.Uoms.Find(id);
            db.Uoms.Remove(uom);
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

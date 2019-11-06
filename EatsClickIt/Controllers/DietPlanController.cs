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
    public class DietPlanController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DietPlan
        public ActionResult Index()
        {
            return View(db.DietPlans.ToList());
        }

        // GET: DietPlan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlans.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // GET: DietPlan/Create
        public ActionResult Create()
        {
			DietPlan dietPlan = new DietPlan();
            return View(dietPlan);
        }

        // POST: DietPlan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DietPlanId,Description,Active,Created")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                dietPlan.Created = DateTime.Now;
				db.DietPlans.Add(dietPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dietPlan);
        }

        // GET: DietPlan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlans.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // POST: DietPlan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DietPlanId,Description,Active,Created")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dietPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dietPlan);
        }

        // GET: DietPlan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlans.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // POST: DietPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DietPlan dietPlan = db.DietPlans.Find(id);
            db.DietPlans.Remove(dietPlan);
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

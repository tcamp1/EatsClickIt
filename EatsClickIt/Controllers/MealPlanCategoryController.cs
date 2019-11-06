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
    public class MealPlanCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MealPlanCategory
        public ActionResult Index()
        {
            return View(db.MealPlanCategories.ToList());
        }

        // GET: MealPlanCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealPlanCategory mealPlanCategory = db.MealPlanCategories.Find(id);
            if (mealPlanCategory == null)
            {
                return HttpNotFound();
            }
            return View(mealPlanCategory);
        }

        // GET: MealPlanCategory/Create
        public ActionResult Create()
        {
			MealPlanCategory mealPlanCategory = new MealPlanCategory();
            return View(mealPlanCategory);
        }

        // POST: MealPlanCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MealPlanCategoryId,Description,Active")] MealPlanCategory mealPlanCategory)
        {
            if (ModelState.IsValid)
            {
                mealPlanCategory.Created = DateTime.Now;
				db.MealPlanCategories.Add(mealPlanCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mealPlanCategory);
        }

        // GET: MealPlanCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealPlanCategory mealPlanCategory = db.MealPlanCategories.Find(id);
            if (mealPlanCategory == null)
            {
                return HttpNotFound();
            }
            return View(mealPlanCategory);
        }

        // POST: MealPlanCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MealPlanCategoryId,Description,Active,Created")] MealPlanCategory mealPlanCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealPlanCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mealPlanCategory);
        }

        // GET: MealPlanCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealPlanCategory mealPlanCategory = db.MealPlanCategories.Find(id);
            if (mealPlanCategory == null)
            {
                return HttpNotFound();
            }
            return View(mealPlanCategory);
        }

        // POST: MealPlanCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MealPlanCategory mealPlanCategory = db.MealPlanCategories.Find(id);
            db.MealPlanCategories.Remove(mealPlanCategory);
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

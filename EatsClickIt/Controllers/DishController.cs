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
    public class DishController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dish
        public ActionResult Index()
        {
            return View(db.Dishes.ToList());
        }

        // GET: Dish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = db.Dishes.Find(id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        // GET: Dish/Create
        public ActionResult Create()
        {
			Dish dish = new Dish();
            return View(dish);
        }

        // POST: Dish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DishId,Description,PhotoFilePath,Active,Created")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                dish.Created = DateTime.Now;
				db.Dishes.Add(dish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dish);
        }

        // GET: Dish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = db.Dishes.Find(id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        // POST: Dish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DishId,Description,PhotoFilePath,Active,Created")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dish);
        }

        // GET: Dish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = db.Dishes.Find(id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        // POST: Dish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dish dish = db.Dishes.Find(id);
            db.Dishes.Remove(dish);
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

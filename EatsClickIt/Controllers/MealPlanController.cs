
namespace EatsClickIt.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using EatsClickIt.DAL;
    using EatsClickIt.Models;
    using EatsClickIt.ViewModels;

    public class MealPlanController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MealPlan
        public ActionResult Index()
        {
            return View(db.MealPlans.ToList());
        }

        // GET: MealPlan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealPlan mealPlan = db.MealPlans.Find(id);
            if (mealPlan == null)
            {
                return HttpNotFound();
            }
            return View(mealPlan);
        }

        // GET: MealPlan/Create
        public ActionResult Create()
        {
            MealPlanViewModel mealPlanDisplay = new MealPlanViewModel();

            mealPlanDisplay.Preparations = new List<PreparationViewModel>();
            mealPlanDisplay.Preparations.Add(new PreparationViewModel());

            MealPlanAssignedCategoryRepository mealPlanAssignedCategoryRepository = new MealPlanAssignedCategoryRepository();
            mealPlanDisplay.MealPlanAssignedCategories = mealPlanAssignedCategoryRepository.GetDisplayList(0);

            MealPlanAssignedDietPlanRepository mealPlanAssignedDietPlanRepository = new MealPlanAssignedDietPlanRepository();
            mealPlanDisplay.MealPlanAssignedDietPlans = mealPlanAssignedDietPlanRepository.GetDisplayList(0);

            NutrientViewModel nutrientViewModel = new NutrientViewModel();
            mealPlanDisplay.NutrientDropDownList = nutrientViewModel.GetDropDownList();

            MealPlanAssignedNutrientRepository mealPlanAssignedNutrientRepository = new MealPlanAssignedNutrientRepository();
            mealPlanDisplay.MealPlanAssignedNutrients = mealPlanAssignedNutrientRepository.GetDisplayList(0);
            mealPlanDisplay.MealPlanAssignedNutrients.Add(new MealPlanAssignedNutrientViewModel());

            MealPlanAssignedDishRepository mealPlanAssignedDishRepository = new MealPlanAssignedDishRepository();
            mealPlanDisplay.MealPlanAssignedDishes = mealPlanAssignedDishRepository.GetDisplayList(0);
            mealPlanDisplay.MealPlanAssignedDishes.Add(new MealPlanAssignedDishViewModel());

            MealPlanAssignedIngredientRepository mealPlanAssignedIngredientRepository = new MealPlanAssignedIngredientRepository();
            mealPlanDisplay.MealPlanAssignedIngredients = mealPlanAssignedIngredientRepository.GetDisplayList(0);
            mealPlanDisplay.MealPlanAssignedIngredients.Add(new MealPlanAssignedIngredientViewModel());

            UomViewModel uomViewModel = new UomViewModel();
            mealPlanDisplay.UomDropDownList = uomViewModel.GetDropDownList();

            DishViewModel dishViewModel = new DishViewModel();
            mealPlanDisplay.DishDropDownList = dishViewModel.GetDropDownList();

            IngredientViewModel ingredientViewModel = new IngredientViewModel();
            mealPlanDisplay.IngredientDropDownList = ingredientViewModel.GetDropDownList();

            return View(mealPlanDisplay);
        }

        // POST: MealPlan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MealPlanId,Description,PhotoFilePath,PrepTime,PrepTimeUnit,CostPerServing,Active,Created,Preparations,MealPlanAssignedCategories,MealPlanAssignedDietPlans,MealPlanAssignedNutrients,MealPlanAssignedDishes,MealPlanAssignedIngredients")] MealPlanViewModel mealPlanDisplay)
        {
            if (ModelState.IsValid)
            {
                MealPlanRepository mealPlanRepository = new MealPlanRepository();
                mealPlanRepository.Add(mealPlanDisplay);
                return RedirectToAction("Index");
            }

            return View(mealPlanDisplay);
        }

        // GET: MealPlan/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MealPlanRepository mealPlanRepository = new MealPlanRepository();
            MealPlanViewModel mealPlanDisplay = mealPlanRepository.GetDisplay(id.Value);

            if (mealPlanDisplay == null)
            {
                return HttpNotFound();
            }

            return View(mealPlanDisplay);
        }

        // POST: MealPlan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MealPlanId,Description,PhotoFilePath,PrepTime,PrepTimeUnit,CostPerServing,Active,Created,Preparations,MealPlanAssignedCategories,MealPlanAssignedDietPlans,MealPlanAssignedNutrients,MealPlanAssignedDishes,MealPlanAssignedIngredients")] MealPlanViewModel mealPlanDisplay)
        {
            if (ModelState.IsValid)
            {
                MealPlanRepository mealPlanRepository = new MealPlanRepository();
                mealPlanRepository.Save(mealPlanDisplay);
                return RedirectToAction("Index");
            }

            return View(mealPlanDisplay);
        }

        // GET: MealPlan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealPlan mealPlan = db.MealPlans.Find(id);
            if (mealPlan == null)
            {
                return HttpNotFound();
            }
            return View(mealPlan);
        }

        // POST: MealPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MealPlan mealPlan = db.MealPlans.Find(id);
            db.MealPlans.Remove(mealPlan);
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

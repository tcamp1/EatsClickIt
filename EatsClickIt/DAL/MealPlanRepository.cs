namespace EatsClickIt.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using EatsClickIt.Models;
    using EatsClickIt.ViewModels;

    public class MealPlanRepository
    {
        public MealPlanViewModel GetDisplay(int mealPlanId)
        {
            MealPlanViewModel mealPlanDisplay = new MealPlanViewModel();

            MealPlan mealPlan = Get(mealPlanId);
            mealPlanDisplay.MealPlanId = mealPlan.MealPlanId;
            mealPlanDisplay.Description = mealPlan.Description;
            mealPlanDisplay.PhotoFilePath = mealPlan.PhotoFilePath;
            mealPlanDisplay.PrepTime = mealPlan.PrepTime;
            mealPlanDisplay.PrepTimeUnit = mealPlan.PrepTimeUnit;
            mealPlanDisplay.CostPerServing = mealPlan.CostPerServing;
            mealPlanDisplay.Active = mealPlan.Active;
            mealPlanDisplay.Created = (System.DateTime)mealPlan.Created;

            PreparationRepository preparationRepository = new PreparationRepository();
            mealPlanDisplay.Preparations = preparationRepository.GetDisplayList(mealPlanId);

            MealPlanAssignedCategoryRepository mealPlanAssignedCategoryRepository = new MealPlanAssignedCategoryRepository();
            mealPlanDisplay.MealPlanAssignedCategories = mealPlanAssignedCategoryRepository.GetDisplayList(mealPlanId);

            MealPlanAssignedDietPlanRepository mealPlanAssignedDietPlanRepository = new MealPlanAssignedDietPlanRepository();
            mealPlanDisplay.MealPlanAssignedDietPlans = mealPlanAssignedDietPlanRepository.GetDisplayList(mealPlanId);

            NutrientViewModel nutrientViewModel = new NutrientViewModel();
            mealPlanDisplay.NutrientDropDownList = nutrientViewModel.GetDropDownList();
            
            MealPlanAssignedNutrientRepository mealPlanAssignedNutrientRepository = new MealPlanAssignedNutrientRepository();
            mealPlanDisplay.MealPlanAssignedNutrients = mealPlanAssignedNutrientRepository.GetDisplayList(mealPlanId);

            MealPlanAssignedIngredientRepository mealPlanAssignedIngredientRepository = new MealPlanAssignedIngredientRepository();
            mealPlanDisplay.MealPlanAssignedIngredients = mealPlanAssignedIngredientRepository.GetDisplayList(mealPlanId);

            MealPlanAssignedDishRepository mealPlanAssignedDishRepository = new MealPlanAssignedDishRepository();
            mealPlanDisplay.MealPlanAssignedDishes = mealPlanAssignedDishRepository.GetDisplayList(mealPlanId);

            UomViewModel uomViewModel = new UomViewModel();
            mealPlanDisplay.UomDropDownList = uomViewModel.GetDropDownList();

            DishViewModel dishViewModel = new DishViewModel();
            mealPlanDisplay.DishDropDownList = dishViewModel.GetDropDownList();

            IngredientViewModel ingredientViewModel = new IngredientViewModel();
            mealPlanDisplay.IngredientDropDownList = ingredientViewModel.GetDropDownList();

            return mealPlanDisplay;
        }

        public MealPlan Get(int mealPlanId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                MealPlan mealPlan = new MealPlan();
                mealPlan = dbContext.MealPlans.Where(x => x.MealPlanId == mealPlanId).Single();
                return mealPlan;
            }
        }

        public void Add(MealPlanViewModel mealPlanDisplay)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            MealPlan mealPlan = new MealPlan();
            mealPlan.Description = mealPlanDisplay.Description;
            mealPlan.PhotoFilePath = mealPlanDisplay.PhotoFilePath;
            mealPlan.PrepTime = mealPlanDisplay.PrepTime;
            mealPlan.PrepTimeUnit = mealPlanDisplay.PrepTimeUnit;
            mealPlan.CostPerServing = mealPlanDisplay.CostPerServing;
            mealPlan.Active = mealPlanDisplay.Active;
            mealPlan.Created = DateTime.Now;
            db.MealPlans.Add(mealPlan);
            db.SaveChanges();

            PreparationRepository preparationRepository = new PreparationRepository();
            preparationRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.Preparations);

            MealPlanAssignedCategoryRepository mealPlanAssignedCategoryRepository = new MealPlanAssignedCategoryRepository();
            mealPlanAssignedCategoryRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedCategories);

            MealPlanAssignedDietPlanRepository mealPlanAssignedDietPlanRepository = new MealPlanAssignedDietPlanRepository();
            mealPlanAssignedDietPlanRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedDietPlans);

            MealPlanAssignedNutrientRepository mealPlanAssignedNutrientRepository = new MealPlanAssignedNutrientRepository();
            mealPlanAssignedNutrientRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedNutrients);

            MealPlanAssignedIngredientRepository mealPlanAssignedIngredientRepository = new MealPlanAssignedIngredientRepository();
            mealPlanAssignedIngredientRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedIngredients);

            MealPlanAssignedDishRepository mealPlanAssignedDishRepository = new MealPlanAssignedDishRepository();
            mealPlanAssignedDishRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedDishes);
        }

        public void Save(MealPlanViewModel mealPlanDisplay)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            MealPlan mealPlan = new MealPlan();
            mealPlan.MealPlanId = mealPlanDisplay.MealPlanId;
            mealPlan.Description = mealPlanDisplay.Description;
            mealPlan.PhotoFilePath = mealPlanDisplay.PhotoFilePath;
            mealPlan.PrepTime = mealPlanDisplay.PrepTime;
            mealPlan.PrepTimeUnit = mealPlanDisplay.PrepTimeUnit;
            mealPlan.CostPerServing = mealPlanDisplay.CostPerServing;
            mealPlan.Active = mealPlanDisplay.Active;
            mealPlan.Created = DateTime.Now;
            db.Entry(mealPlan).State = EntityState.Modified;
            db.SaveChanges();

            PreparationRepository preparationRepository = new PreparationRepository();
            preparationRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.Preparations);

            MealPlanAssignedCategoryRepository mealPlanAssignedCategoryRepository = new MealPlanAssignedCategoryRepository();
            mealPlanAssignedCategoryRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedCategories);

            MealPlanAssignedDietPlanRepository mealPlanAssignedDietPlanRepository = new MealPlanAssignedDietPlanRepository();
            mealPlanAssignedDietPlanRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedDietPlans);

            MealPlanAssignedNutrientRepository mealPlanAssignedNutrientRepository = new MealPlanAssignedNutrientRepository();
            mealPlanAssignedNutrientRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedNutrients);

            MealPlanAssignedIngredientRepository mealPlanAssignedIngredientRepository = new MealPlanAssignedIngredientRepository();
            mealPlanAssignedIngredientRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedIngredients);

            MealPlanAssignedDishRepository mealPlanAssignedDishRepository = new MealPlanAssignedDishRepository();
            mealPlanAssignedDishRepository.ProcessList(mealPlan.MealPlanId, mealPlanDisplay.MealPlanAssignedDishes);
        }
    }
}
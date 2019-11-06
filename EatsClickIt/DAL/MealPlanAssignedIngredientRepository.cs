namespace EatsClickIt.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using EatsClickIt.Models;
    using EatsClickIt.ViewModels;

    public class MealPlanAssignedIngredientRepository
    {
        /// <summary>
        /// Get a single MealPlanAssignedIngredient View Model
        /// </summary>
        /// <param name="mealPlanAssignedIngredientId"></param>
        /// <returns></returns>
        public MealPlanAssignedIngredientViewModel GetDisplay(int mealPlanAssignedIngredientId)
        {

            MealPlanAssignedIngredient mealPlanAssignedIngredient = Get(mealPlanAssignedIngredientId);
            MealPlanAssignedIngredientViewModel mealPlanAssignedIngredientViewModel = new MealPlanAssignedIngredientViewModel();
            mealPlanAssignedIngredientViewModel.MealPlanAssignedIngredientId = mealPlanAssignedIngredient.MealPlanAssignedIngredientId;
            mealPlanAssignedIngredientViewModel.MealPlanId = mealPlanAssignedIngredient.MealPlanId;
            mealPlanAssignedIngredientViewModel.IngredientId = mealPlanAssignedIngredient.IngredientId;
            mealPlanAssignedIngredientViewModel.Quantity = mealPlanAssignedIngredient.Quantity;
            mealPlanAssignedIngredientViewModel.UomId = mealPlanAssignedIngredient.UomId;
            mealPlanAssignedIngredientViewModel.Active = mealPlanAssignedIngredient.Active;
            return mealPlanAssignedIngredientViewModel;
        }

        /// <summary>
        /// Get a MealPlanAssignedIngredient based on Id
        /// </summary>
        /// <param name="mealPlanAssignedIngredientId"></param>
        /// <returns></returns>
        public MealPlanAssignedIngredient Get(int mealPlanAssignedIngredientId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                MealPlanAssignedIngredient mealPlanAssignedIngredient = new MealPlanAssignedIngredient();
                mealPlanAssignedIngredient = dbContext.MealPlanAssignedIngredients.Where(x => x.MealPlanAssignedIngredientId == mealPlanAssignedIngredientId).Single();
                return mealPlanAssignedIngredient;
            }
        }

        /// <summary>
        /// Get a list of the MealPlanAssignedIngredients associated with a Meal Plan (View Model)
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <returns></returns>
        public List<MealPlanAssignedIngredientViewModel> GetDisplayList(int mealPlanId)
        {

            var dbContext = new ApplicationDbContext();
            List<MealPlanAssignedIngredientViewModel> mealPlanAssignedIngredientsViewModel = new List<MealPlanAssignedIngredientViewModel>();

            mealPlanAssignedIngredientsViewModel = dbContext.MealPlanAssignedIngredients.AsNoTracking().Where(x => x.MealPlanId == mealPlanId).Select(x =>
                                    new MealPlanAssignedIngredientViewModel
                                    {
                                        MealPlanAssignedIngredientId = x.MealPlanAssignedIngredientId,
                                        MealPlanId = x.MealPlanId,
                                        IngredientId = x.IngredientId,
                                        Quantity = x.Quantity,
                                        UomId = x.UomId,
                                        Active = x.Active
                                    }).ToList();

            return mealPlanAssignedIngredientsViewModel;
        }

        /// <summary>
        /// Process the MealPlanAssignedIngredients sent by a Meal Plan.  These are added if new (MealPlanAssignedIngredientId < 1)
        /// Updated if MealPlanAssignedIngredientId > 0
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <param name="mealPlanAssignedIngredients"></param>
        public void ProcessList(int mealPlanId, List<MealPlanAssignedIngredientViewModel> mealPlanAssignedIngredients)
        {
            foreach (MealPlanAssignedIngredientViewModel mealPlanAssignedIngredientDisplay in mealPlanAssignedIngredients)
            {
                MealPlanAssignedIngredient mealPlanAssignedIngredient = new MealPlanAssignedIngredient();
                mealPlanAssignedIngredient.MealPlanAssignedIngredientId = mealPlanAssignedIngredientDisplay.MealPlanAssignedIngredientId;
                mealPlanAssignedIngredient.MealPlanId = mealPlanId;
                mealPlanAssignedIngredient.IngredientId = mealPlanAssignedIngredientDisplay.IngredientId;
                mealPlanAssignedIngredient.Quantity = mealPlanAssignedIngredientDisplay.Quantity;
                mealPlanAssignedIngredient.UomId = mealPlanAssignedIngredientDisplay.UomId;
                mealPlanAssignedIngredient.Active = mealPlanAssignedIngredientDisplay.Active;

                using (var dbContext = new ApplicationDbContext())
                {
                    if (mealPlanAssignedIngredientDisplay.MealPlanAssignedIngredientId > 0)
                    {
                        dbContext.Entry(mealPlanAssignedIngredient).State = EntityState.Modified;
                    }
                    else
                    {
                        mealPlanAssignedIngredient.Created = DateTime.Now;
                        dbContext.MealPlanAssignedIngredients.Add(mealPlanAssignedIngredient);
                    }

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
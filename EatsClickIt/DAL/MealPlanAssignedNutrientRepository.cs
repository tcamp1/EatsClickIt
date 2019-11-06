namespace EatsClickIt.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using EatsClickIt.Models;
    using EatsClickIt.ViewModels;

    public class MealPlanAssignedNutrientRepository
    {
        /// <summary>
        /// Get a single MealPlanAssignedNutrient View Model
        /// </summary>
        /// <param name="mealPlanAssignedNutrientId"></param>
        /// <returns></returns>
        public MealPlanAssignedNutrientViewModel GetDisplay(int mealPlanAssignedNutrientId)
        {

            MealPlanAssignedNutrient mealPlanAssignedNutrient = Get(mealPlanAssignedNutrientId);
            MealPlanAssignedNutrientViewModel mealPlanAssignedNutrientViewModel = new MealPlanAssignedNutrientViewModel();
            mealPlanAssignedNutrientViewModel.MealPlanAssignedNutrientId = mealPlanAssignedNutrient.MealPlanAssignedNutrientId;
            mealPlanAssignedNutrientViewModel.MealPlanId = mealPlanAssignedNutrient.MealPlanId;
            mealPlanAssignedNutrientViewModel.NutritientId = mealPlanAssignedNutrient.NutritientId;
            mealPlanAssignedNutrientViewModel.Quantity = mealPlanAssignedNutrient.Quantity;
            mealPlanAssignedNutrientViewModel.UomId = mealPlanAssignedNutrient.UomId;
            mealPlanAssignedNutrientViewModel.Active = mealPlanAssignedNutrient.Active;
            return mealPlanAssignedNutrientViewModel;
        }

        /// <summary>
        /// Get a MealPlanAssignedNutrient based on Id
        /// </summary>
        /// <param name="mealPlanAssignedNutrientId"></param>
        /// <returns></returns>
        public MealPlanAssignedNutrient Get(int mealPlanAssignedNutrientId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                MealPlanAssignedNutrient mealPlanAssignedNutrient = new MealPlanAssignedNutrient();
                mealPlanAssignedNutrient = dbContext.MealPlanAssignedNutrients.Where(x => x.MealPlanAssignedNutrientId == mealPlanAssignedNutrientId).Single();
                return mealPlanAssignedNutrient;
            }
        }

        /// <summary>
        /// Get a list of the MealPlanAssignedNutrients associated with a Meal Plan (View Model)
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <returns></returns>
        public List<MealPlanAssignedNutrientViewModel> GetDisplayList(int mealPlanId)
        {

            var dbContext = new ApplicationDbContext();
            List<MealPlanAssignedNutrientViewModel> mealPlanAssignedNutrientsViewModel = new List<MealPlanAssignedNutrientViewModel>();

            mealPlanAssignedNutrientsViewModel = dbContext.MealPlanAssignedNutrients.AsNoTracking().Where(x => x.MealPlanId == mealPlanId).Select(x =>
                                    new MealPlanAssignedNutrientViewModel
                                    {
                                        MealPlanAssignedNutrientId = x.MealPlanAssignedNutrientId,
                                        MealPlanId = x.MealPlanId,
                                        NutritientId = x.NutritientId,
                                        Quantity = x.Quantity,
                                        UomId = x.UomId,
                                        Active = x.Active
                                    }).ToList();

            return mealPlanAssignedNutrientsViewModel;
        }

        /// <summary>
        /// Process the MealPlanAssignedNutrients sent by a Meal Plan.  These are added if new (MealPlanAssignedNutrientId < 1)
        /// Updated if MealPlanAssignedNutrientId > 0
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <param name="mealPlanAssignedNutrients"></param>
        public void ProcessList(int mealPlanId, List<MealPlanAssignedNutrientViewModel> mealPlanAssignedNutrients)
        {
            foreach (MealPlanAssignedNutrientViewModel mealPlanAssignedNutrientDisplay in mealPlanAssignedNutrients)
            {
                MealPlanAssignedNutrient mealPlanAssignedNutrient = new MealPlanAssignedNutrient();
                mealPlanAssignedNutrient.MealPlanAssignedNutrientId = mealPlanAssignedNutrientDisplay.MealPlanAssignedNutrientId;
                mealPlanAssignedNutrient.MealPlanId = mealPlanId;
                mealPlanAssignedNutrient.NutritientId = mealPlanAssignedNutrientDisplay.NutritientId;
                mealPlanAssignedNutrient.Quantity = mealPlanAssignedNutrientDisplay.Quantity;
                mealPlanAssignedNutrient.UomId = mealPlanAssignedNutrientDisplay.UomId;
                mealPlanAssignedNutrient.Active = mealPlanAssignedNutrientDisplay.Active;

                using (var dbContext = new ApplicationDbContext())
                {
                    if (mealPlanAssignedNutrientDisplay.MealPlanAssignedNutrientId > 0)
                    {
                        dbContext.Entry(mealPlanAssignedNutrient).State = EntityState.Modified;
                    }
                    else
                    {
                        mealPlanAssignedNutrient.Created = DateTime.Now;
                        dbContext.MealPlanAssignedNutrients.Add(mealPlanAssignedNutrient);
                    }

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
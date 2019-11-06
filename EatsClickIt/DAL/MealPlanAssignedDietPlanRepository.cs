namespace EatsClickIt.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using EatsClickIt.Models;
    using EatsClickIt.ViewModels;

    public class MealPlanAssignedDietPlanRepository
    {
        /// <summary>
        /// Get a single MealPlanAssignedDietPlan View Model
        /// </summary>
        /// <param name="mealPlanAssignedDietPlanId"></param>
        /// <returns></returns>
        public MealPlanAssignedDietPlanViewModel GetDisplay(int mealPlanAssignedDietPlanId)
        {

            MealPlanAssignedDietPlan mealPlanAssignedDietPlan = Get(mealPlanAssignedDietPlanId);
            MealPlanAssignedDietPlanViewModel mealPlanAssignedDietPlanViewModel = new MealPlanAssignedDietPlanViewModel();
            mealPlanAssignedDietPlanViewModel.MealPlanDietPlanId = mealPlanAssignedDietPlan.MealPlanDietPlanId;
            mealPlanAssignedDietPlanViewModel.MealPlanId = mealPlanAssignedDietPlan.MealPlanId;
            mealPlanAssignedDietPlanViewModel.DietPlanId = mealPlanAssignedDietPlan.DietPlanId;
            mealPlanAssignedDietPlanViewModel.Active = mealPlanAssignedDietPlan.Active;
            return mealPlanAssignedDietPlanViewModel;
        }

        /// <summary>
        /// Get a MealPlanAssignedDietPlan based on Id
        /// </summary>
        /// <param name="mealPlanAssignedDietPlanId"></param>
        /// <returns></returns>
        public MealPlanAssignedDietPlan Get(int mealPlanAssignedDietPlanId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                MealPlanAssignedDietPlan mealPlanAssignedDietPlan = new MealPlanAssignedDietPlan();
                mealPlanAssignedDietPlan = dbContext.MealPlanAssignedDietPlans.Where(x => x.MealPlanDietPlanId == mealPlanAssignedDietPlanId).Single();
                return mealPlanAssignedDietPlan;
            }
        }

        /// <summary>
        /// Get a list of the MealPlanAssignedDietPlans associated with a Meal Plan (View Model)
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <returns></returns>
        public List<MealPlanAssignedDietPlanViewModel> GetDisplayList(int mealPlanId)
        {

            var dbContext = new ApplicationDbContext();
            List<MealPlanAssignedDietPlanViewModel> mealPlanAssignedDietPlansViewModel = new List<MealPlanAssignedDietPlanViewModel>();

            mealPlanAssignedDietPlansViewModel = dbContext.DietPlans.AsNoTracking().Select(x =>
                                    new MealPlanAssignedDietPlanViewModel
                                    {
                                        DietPlanId = x.DietPlanId,
                                        DietPlanDescription = x.Description,
                                        Active = x.Active
                                    }).ToList();

            foreach (MealPlanAssignedDietPlanViewModel mpac in mealPlanAssignedDietPlansViewModel)
            {
                // Lookup assigned diet plans 
                MealPlanAssignedDietPlan mealPlanAssignedDietPlan = dbContext.MealPlanAssignedDietPlans.Where(x => x.MealPlanId == mealPlanId && x.DietPlanId == mpac.DietPlanId).FirstOrDefault();
                if (mealPlanAssignedDietPlan != null)
                {
                    mpac.MealPlanDietPlanId = mealPlanAssignedDietPlan.MealPlanDietPlanId;
                    mpac.MealPlanId = mealPlanId;
                    mpac.DietPlanId = mealPlanAssignedDietPlan.DietPlanId;
                    mpac.Active = mealPlanAssignedDietPlan.Active;
                }
            }

            return mealPlanAssignedDietPlansViewModel;
        }

        /// <summary>
        /// Process the MealPlanAssignedDietPlans sent by a Meal Plan.  These are added if new (MealPlanAssignedDietPlanId < 1)
        /// Updated if MealPlanAssignedDietPlanId > 0
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <param name="mealPlanAssignedDietPlans"></param>
        public void ProcessList(int mealPlanId, List<MealPlanAssignedDietPlanViewModel> mealPlanAssignedDietPlans)
        {
            foreach (MealPlanAssignedDietPlanViewModel mealPlanAssignedDietPlanDisplay in mealPlanAssignedDietPlans)
            {
                MealPlanAssignedDietPlan mealPlanAssignedDietPlan = new MealPlanAssignedDietPlan();
                mealPlanAssignedDietPlan.MealPlanDietPlanId = mealPlanAssignedDietPlanDisplay.MealPlanDietPlanId;
                mealPlanAssignedDietPlan.MealPlanId = mealPlanId;
                mealPlanAssignedDietPlan.DietPlanId = mealPlanAssignedDietPlanDisplay.DietPlanId;
                mealPlanAssignedDietPlan.Active = mealPlanAssignedDietPlanDisplay.Active;

                using (var dbContext = new ApplicationDbContext())
                {
                    if (mealPlanAssignedDietPlanDisplay.MealPlanDietPlanId > 0)
                    {
                        dbContext.Entry(mealPlanAssignedDietPlan).State = EntityState.Modified;
                    }
                    else
                    {
                        mealPlanAssignedDietPlan.Created = DateTime.Now;
                        dbContext.MealPlanAssignedDietPlans.Add(mealPlanAssignedDietPlan);
                    }

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
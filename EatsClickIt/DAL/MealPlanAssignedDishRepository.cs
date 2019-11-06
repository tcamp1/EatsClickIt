namespace EatsClickIt.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using EatsClickIt.Models;
    using EatsClickIt.ViewModels;

    public class MealPlanAssignedDishRepository
    {
        /// <summary>
        /// Get a single MealPlanAssignedDish View Model
        /// </summary>
        /// <param name="mealPlanAssignedDishId"></param>
        /// <returns></returns>
        public MealPlanAssignedDishViewModel GetDisplay(int mealPlanAssignedDishId)
        {

            MealPlanAssignedDish mealPlanAssignedDish = Get(mealPlanAssignedDishId);
            MealPlanAssignedDishViewModel mealPlanAssignedDishViewModel = new MealPlanAssignedDishViewModel();
            mealPlanAssignedDishViewModel.MealPlanAssignedDishId = mealPlanAssignedDish.MealPlanAssignedDishId;
            mealPlanAssignedDishViewModel.MealPlanId = mealPlanAssignedDish.MealPlanId;
            mealPlanAssignedDishViewModel.DishId = mealPlanAssignedDish.DishId;
            mealPlanAssignedDishViewModel.Active = mealPlanAssignedDish.Active;
            return mealPlanAssignedDishViewModel;
        }

        /// <summary>
        /// Get a MealPlanAssignedDish based on Id
        /// </summary>
        /// <param name="mealPlanAssignedDishId"></param>
        /// <returns></returns>
        public MealPlanAssignedDish Get(int mealPlanAssignedDishId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                MealPlanAssignedDish mealPlanAssignedDish = new MealPlanAssignedDish();
                mealPlanAssignedDish = dbContext.MealPlanAssignedDishes.Where(x => x.MealPlanAssignedDishId == mealPlanAssignedDishId).Single();
                return mealPlanAssignedDish;
            }
        }

        /// <summary>
        /// Get a list of the MealPlanAssignedDishs associated with a Meal Plan (View Model)
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <returns></returns>
        public List<MealPlanAssignedDishViewModel> GetDisplayList(int mealPlanId)
        {

            var dbContext = new ApplicationDbContext();
            List<MealPlanAssignedDishViewModel> mealPlanAssignedDishsViewModel = new List<MealPlanAssignedDishViewModel>();

            mealPlanAssignedDishsViewModel = dbContext.MealPlanAssignedDishes.AsNoTracking().Where(x => x.MealPlanId == mealPlanId).Select(x =>
                                    new MealPlanAssignedDishViewModel
                                    {
                                        MealPlanAssignedDishId = x.MealPlanAssignedDishId,
                                        MealPlanId = x.MealPlanId,
                                        DishId = x.DishId,
                                        Active = x.Active
                                    }).ToList();

            return mealPlanAssignedDishsViewModel;
        }

        /// <summary>
        /// Process the MealPlanAssignedDishs sent by a Meal Plan.  These are added if new (MealPlanAssignedDishId < 1)
        /// Updated if MealPlanAssignedDishId > 0
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <param name="mealPlanAssignedDishs"></param>
        public void ProcessList(int mealPlanId, List<MealPlanAssignedDishViewModel> mealPlanAssignedDishes)
        {
            foreach (MealPlanAssignedDishViewModel mealPlanAssignedDishDisplay in mealPlanAssignedDishes)
            {
                MealPlanAssignedDish mealPlanAssignedDish = new MealPlanAssignedDish();
                mealPlanAssignedDish.MealPlanAssignedDishId = mealPlanAssignedDishDisplay.MealPlanAssignedDishId;
                mealPlanAssignedDish.MealPlanId = mealPlanId;
                mealPlanAssignedDish.DishId = mealPlanAssignedDishDisplay.DishId;
                mealPlanAssignedDish.Active = mealPlanAssignedDishDisplay.Active;

                using (var dbContext = new ApplicationDbContext())
                {
                    if (mealPlanAssignedDishDisplay.MealPlanAssignedDishId > 0)
                    {
                        dbContext.Entry(mealPlanAssignedDish).State = EntityState.Modified;
                    }
                    else
                    {
                        mealPlanAssignedDish.Created = DateTime.Now;
                        dbContext.MealPlanAssignedDishes.Add(mealPlanAssignedDish);
                    }

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
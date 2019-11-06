namespace EatsClickIt.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using EatsClickIt.Models;
    using EatsClickIt.ViewModels;

    public class MealPlanAssignedCategoryRepository
    {
        /// <summary>
        /// Get a single MealPlanAssignedCategory View Model
        /// </summary>
        /// <param name="mealPlanAssignedCategoryId"></param>
        /// <returns></returns>
        public MealPlanAssignedCategoryViewModel GetDisplay(int mealPlanAssignedCategoryId)
        {

            MealPlanAssignedCategory mealPlanAssignedCategory = Get(mealPlanAssignedCategoryId);
            MealPlanAssignedCategoryViewModel mealPlanAssignedCategoryViewModel = new MealPlanAssignedCategoryViewModel();
            mealPlanAssignedCategoryViewModel.MealPlanAssignedCategoryId = mealPlanAssignedCategory.MealPlanAssignedCategoryId;
            mealPlanAssignedCategoryViewModel.MealPlanId = mealPlanAssignedCategory.MealPlanId;
            mealPlanAssignedCategoryViewModel.MealPlanCategoryId = mealPlanAssignedCategory.MealPlanCategoryId;
            mealPlanAssignedCategoryViewModel.Active = mealPlanAssignedCategory.Active;
            return mealPlanAssignedCategoryViewModel;
        }

        /// <summary>
        /// Get a MealPlanAssignedCategory based on Id
        /// </summary>
        /// <param name="mealPlanAssignedCategoryId"></param>
        /// <returns></returns>
        public MealPlanAssignedCategory Get(int mealPlanAssignedCategoryId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                MealPlanAssignedCategory mealPlanAssignedCategory = new MealPlanAssignedCategory();
                mealPlanAssignedCategory = dbContext.MealPlanAssignedCategories.Where(x => x.MealPlanAssignedCategoryId == mealPlanAssignedCategoryId).Single();
                return mealPlanAssignedCategory;
            }
        }

        /// <summary>
        /// Get a list of the MealPlanAssignedCategorys associated with a Meal Plan (View Model)
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <returns></returns>
        public List<MealPlanAssignedCategoryViewModel> GetDisplayList(int mealPlanId)
        {

            var dbContext = new ApplicationDbContext();
            List<MealPlanAssignedCategoryViewModel> mealPlanAssignedCategoriesViewModel = new List<MealPlanAssignedCategoryViewModel>();

            mealPlanAssignedCategoriesViewModel = dbContext.MealPlanCategories.AsNoTracking().Select(x =>
                                    new MealPlanAssignedCategoryViewModel
                                    {
                                        MealPlanCategoryId = x.MealPlanCategoryId,
                                        MealPlanCategoryDescription = x.Description,
                                        Active = x.Active
                                    }).ToList();

            foreach(MealPlanAssignedCategoryViewModel mpac in mealPlanAssignedCategoriesViewModel)
            {
                // Lookup assigned category 
                MealPlanAssignedCategory mealPlanAssignedCategory = dbContext.MealPlanAssignedCategories.Where(x => x.MealPlanId == mealPlanId && x.MealPlanCategoryId == mpac.MealPlanCategoryId).FirstOrDefault();
                if(mealPlanAssignedCategory != null)
                {
                    mpac.MealPlanAssignedCategoryId = mealPlanAssignedCategory.MealPlanAssignedCategoryId;
                    mpac.MealPlanId = mealPlanId;
                    mpac.MealPlanCategoryId = mealPlanAssignedCategory.MealPlanCategoryId;
                    mpac.Active = mealPlanAssignedCategory.Active;
                }
            }

            return mealPlanAssignedCategoriesViewModel;
        }

        /// <summary>
        /// Process the MealPlanAssignedCategorys sent by a Meal Plan.  These are added if new (MealPlanAssignedCategoryId < 1)
        /// Updated if MealPlanAssignedCategoryId > 0
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <param name="mealPlanAssignedCategorys"></param>
        public void ProcessList(int mealPlanId, List<MealPlanAssignedCategoryViewModel> mealPlanAssignedCategories)
        {
            foreach (MealPlanAssignedCategoryViewModel mealPlanAssignedCategoryDisplay in mealPlanAssignedCategories)
            {
                MealPlanAssignedCategory mealPlanAssignedCategory = new MealPlanAssignedCategory();
                mealPlanAssignedCategory.MealPlanAssignedCategoryId = mealPlanAssignedCategoryDisplay.MealPlanAssignedCategoryId;
                mealPlanAssignedCategory.MealPlanId = mealPlanId;
                mealPlanAssignedCategory.MealPlanCategoryId = mealPlanAssignedCategoryDisplay.MealPlanCategoryId;
                mealPlanAssignedCategory.Active = mealPlanAssignedCategoryDisplay.Active;

                using (var dbContext = new ApplicationDbContext())
                {
                    if (mealPlanAssignedCategoryDisplay.MealPlanAssignedCategoryId > 0)
                    {
                        dbContext.Entry(mealPlanAssignedCategory).State = EntityState.Modified;
                    }
                    else
                    {
                        mealPlanAssignedCategory.Created = DateTime.Now;
                        dbContext.MealPlanAssignedCategories.Add(mealPlanAssignedCategory);
                    }

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
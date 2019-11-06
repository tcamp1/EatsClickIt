namespace EatsClickIt.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using EatsClickIt.Models;
    using EatsClickIt.ViewModels;

    public class PreparationRepository
    {
        /// <summary>
        /// Get a single Preparation View Model
        /// </summary>
        /// <param name="preparationId"></param>
        /// <returns></returns>
        public PreparationViewModel GetDisplay(int preparationId)
        {

            Preparation preparation = Get(preparationId);
            PreparationViewModel preparationViewModel = new PreparationViewModel();
            preparationViewModel.PreparationId = preparation.PreparationId;
            preparationViewModel.MealPlanId = preparation.MealPlanId;
            preparationViewModel.Instruction = preparation.Instruction;
            preparationViewModel.Active = preparation.Active;
            return preparationViewModel;
        }

        /// <summary>
        /// Get a Preparation based on Id
        /// </summary>
        /// <param name="preparationId"></param>
        /// <returns></returns>
        public Preparation Get(int preparationId)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Preparation preparation = new Preparation();
                preparation = dbContext.Preparations.Where(x => x.PreparationId == preparationId).Single();
                return preparation;
            }
        }

        /// <summary>
        /// Get a list of the Preparations associated with a Meal Plan (View Model)
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <returns></returns>
        public List<PreparationViewModel> GetDisplayList(int mealPlanId)
        {
            List<PreparationViewModel> preparationsViewModel = new List<PreparationViewModel>();

            using (var dbContext = new ApplicationDbContext())
            {

                preparationsViewModel = dbContext.Preparations.AsNoTracking().Where(x => x.MealPlanId == mealPlanId).OrderBy(x => x.Sequence)
                                        .Select(x =>
                                        new PreparationViewModel
                                        {
                                            PreparationId = x.PreparationId,
                                            MealPlanId = x.MealPlanId,
                                            Sequence = x.Sequence,
                                            Instruction = x.Instruction,
                                            Active = x.Active
                                        }).ToList();
            }

            return preparationsViewModel;
        }

        /// <summary>
        /// Process the Preparations sent by a Meal Plan.  These are added if new (PreparationId < 1)
        /// Updated if PreparationId > 0
        /// </summary>
        /// <param name="mealPlanId"></param>
        /// <param name="preparations"></param>
        public void ProcessList(int mealPlanId, List<PreparationViewModel> preparations)
        {
            foreach (PreparationViewModel preparationDisplay in preparations)
            {
                Preparation preparation = new Preparation();
                preparation.PreparationId = preparationDisplay.PreparationId;
                preparation.MealPlanId = mealPlanId;
                preparation.Sequence = preparationDisplay.Sequence;
                preparation.Instruction = preparationDisplay.Instruction;
                preparation.Active = preparationDisplay.Active;
                preparation.Created = DateTime.Now;

                using (var dbContext = new ApplicationDbContext())
                {
                    if (preparationDisplay.PreparationId > 0)
                    {
                        dbContext.Entry(preparation).State = EntityState.Modified;
                    }
                    else
                    {
                        preparation.Created = DateTime.Now;
                        dbContext.Preparations.Add(preparation);
                    }

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
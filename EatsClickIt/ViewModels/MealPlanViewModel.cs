//-----------------------------------------------------------------------
// <copyright file="MealPlanViewModel.cs" company="University of Memphis">
//     Copyright (c) University of Memphis All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EatsClickIt.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Meal Plan View Model class
    /// This houses Meal Plans (component of a Diet Plan)
    /// </summary>
    public class MealPlanViewModel
    {

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [DisplayName("Meal Plan ID")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan Description
        /// </summary>
        [Required]
        [StringLength(1024, MinimumLength = 1)]
        [DisplayName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Path for the photo
        /// </summary>
        [Required]
        [DisplayName("Photo file path")]
        [StringLength(512, MinimumLength = 1)]
        public string PhotoFilePath { get; set; }

        /// <summary>
        /// Gets or sets preparation time
        /// </summary>
        [Required]
        [DisplayName("Preparation Time")]
        public int PrepTime { get; set; }

        /// <summary>
        /// Gets or sets preparation time units (e.g. minutes, hours)
        /// </summary>
        [Required]
        [DisplayName("Preparation Time Unit")]
        public string PrepTimeUnit { get; set; }

        /// <summary>
        /// Gets or sets cost per serving
        /// </summary>
        [Required]
        [DisplayName("Cost per serving")]
        public decimal CostPerServing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the date and time the record was created
        /// </summary>
        [DisplayName("Create Timestamp")]
        public DateTime Created { get; set; }

        public List<PreparationViewModel> Preparations { get; set; }
        public List<MealPlanAssignedCategoryViewModel> MealPlanAssignedCategories { get; set; }
        public List<MealPlanAssignedDietPlanViewModel> MealPlanAssignedDietPlans { get; set; }
        public IEnumerable<NutrientViewModel> NutrientDropDownList { get; set; }
        public List<MealPlanAssignedNutrientViewModel> MealPlanAssignedNutrients { get; set; }
        public List<MealPlanAssignedIngredientViewModel> MealPlanAssignedIngredients { get; set; }
        public List<MealPlanAssignedDishViewModel> MealPlanAssignedDishes { get; set; }
        public IEnumerable<UomViewModel> UomDropDownList { get; set; }
        public IEnumerable<DishViewModel> DishDropDownList { get; set; }
        public IEnumerable<IngredientViewModel> IngredientDropDownList { get; set; }
    }
}
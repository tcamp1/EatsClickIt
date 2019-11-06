//-----------------------------------------------------------------------
// <copyright file="MealPlanAssignedDish.cs" company="University of Memphis">
//     Copyright (c) University of Memphis All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EatsClickIt.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Meal Plan Assigned Dish class
    /// This houses those Dishes to the Meal Plan
    /// </summary>
    public class MealPlanAssignedDishViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanAssignedDish"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanAssignedDishViewModel()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Meal Plan Diet Plan ID
        /// </summary>
        [DisplayName("Meal Plan Assigned Dish Id")]
        public int MealPlanAssignedDishId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [DisplayName("MealPlanId")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Dish ID
        /// </summary>
        [DisplayName("DishId")]
        public int DishId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }

    }
}
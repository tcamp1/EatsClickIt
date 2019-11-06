//-----------------------------------------------------------------------
// <copyright file="MealPlanAssignedCategory.cs" company="University of Memphis">
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
    /// Meal Plan Assigned Category class
    /// This houses those Categories to the Meal Plan
    /// </summary>
    public class MealPlanAssignedCategoryViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanAssignedCategoryViewModel"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanAssignedCategoryViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the Meal Assigned Category ID
        /// </summary>
        [DisplayName("Meal Plan Assigned Category Id")]
        public int MealPlanAssignedCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [DisplayName("Meal Plan Id")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan Category ID
        /// </summary>
        [DisplayName("Meal Plan Category Id")]
        public int MealPlanCategoryId { get; set; }

        public string MealPlanCategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }

    }
}
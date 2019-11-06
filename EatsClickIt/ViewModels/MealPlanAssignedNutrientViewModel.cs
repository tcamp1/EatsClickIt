//-----------------------------------------------------------------------
// <copyright file="MealPlanAssignedNutrient.cs" company="University of Memphis">
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
    /// Meal Plan Assigned Nutritient class
    /// This houses Nutrients assigned to a Meal Plan
    /// </summary>
    public class MealPlanAssignedNutrientViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanAssignedNutrient"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanAssignedNutrientViewModel()
        {
            this.Active = true;
            this.Quantity = 0;
        }

        /// <summary>
        /// Gets or sets the Nutrition ID
        /// </summary>
        [DisplayName("Meal Plan Assigned Nutritient ID")]
        public int MealPlanAssignedNutrientId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [DisplayName("Meal Plan ID")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Nutritient ID
        /// </summary>
        [DisplayName("Nutritient ID")]
        public int NutritientId { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        [DisplayName("Quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Unit of Measure ID
        /// </summary>
        [DisplayName("UOM ID")]
        public int UomId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }
    }
}
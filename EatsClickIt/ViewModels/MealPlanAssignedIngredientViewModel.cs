//-----------------------------------------------------------------------
// <copyright file="MealPlanAssignedIngredient.cs" company="University of Memphis">
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
    /// Meal Plan Assigned Ingredient class
    /// This houses those ingredients assigned to the Meal Plan
    /// </summary>
    public class MealPlanAssignedIngredientViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanAssignedIngredient"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanAssignedIngredientViewModel()
        {
            this.Active = true;
            this.Quantity = 0;
        }

        /// <summary>
        /// Gets or sets the Meal Plan Assigned Ingredient ID
        /// </summary>
        [DisplayName("Meal Plan Assigned Ingredient ID")]
        public int MealPlanAssignedIngredientId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [DisplayName("Meal Plan ID")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Ingredient ID
        /// </summary>
        [DisplayName("Ingredient ID")]
        public int IngredientId { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        [DisplayName("Quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Unit of Measure ID
        /// </summary>
        [ForeignKey("Uom")]
        [DisplayName("UOM ID")]
        public int UomId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }
    }
}
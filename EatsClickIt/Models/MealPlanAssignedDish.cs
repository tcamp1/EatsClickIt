//-----------------------------------------------------------------------
// <copyright file="MealPlanAssignedDish.cs" company="University of Memphis">
//     Copyright (c) University of Memphis All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EatsClickIt.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Meal Plan Assigned Dish class
    /// This houses those Dishes to the Meal Plan
    /// </summary>
    public class MealPlanAssignedDish
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanAssignedDish"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanAssignedDish()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Meal Plan Diet Plan ID
        /// </summary>
        [Key]
        [DisplayName("Meal Plan Assigned Dish Id")]
        public int MealPlanAssignedDishId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [ForeignKey("MealPlan")]
        [DisplayName("MealPlanId")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Dish ID
        /// </summary>
        [ForeignKey("Dish")]
        [DisplayName("DishId")]
        public int DishId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the date and time the record was created
        /// </summary>
        [DisplayName("Create Timestamp")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan Category navigation property
        /// </summary>
        // public virtual Dish Dishes { get; set; }

        /// <summary>
        /// Gets or sets Diet Plan navigation property
        /// </summary>
        [ForeignKey("DishId")]
        [InverseProperty("MealPlanAssignedDishes")]
        public virtual Dish Dish { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan navigation property
        /// </summary>
        [ForeignKey("MealPlanID")]
        [InverseProperty("MealPlanAssignedDishes")]
        public virtual MealPlan MealPlan { get; set; }
    }
}
//-----------------------------------------------------------------------
// <copyright file="MealPlanAssignedCategory.cs" company="University of Memphis">
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
    /// Meal Plan Assigned Category class
    /// This houses those Categories to the Meal Plan
    /// </summary>
    public class MealPlanAssignedCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanAssignedCategory"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanAssignedCategory()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Meal Assigned Category ID
        /// </summary>
        [Key]
        [DisplayName("Meal Plan Assigned Category Id")]
        public int MealPlanAssignedCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [ForeignKey("MealPlan")]
        [DisplayName("Meal Plan Id")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan Category ID
        /// </summary>
        [ForeignKey("MealPlanCategory")]
        [DisplayName("Meal Plan Category Id")]
        public int MealPlanCategoryId { get; set; }

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
        [ForeignKey("MealPlanCategoryID")]
        [InverseProperty("MealPlanAssignedCategories")]
        public virtual MealPlanCategory MealPlanCategory { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan navigation property
        /// </summary>
        [ForeignKey("MealPlanID")]
        [InverseProperty("MealPlanAssignedCategories")]
        public virtual MealPlan MealPlan { get; set; }
    }
}
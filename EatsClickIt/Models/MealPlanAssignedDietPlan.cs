//-----------------------------------------------------------------------
// <copyright file="MealPlanAssignedDietPlan.cs" company="University of Memphis">
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
    /// Meal Plan Diet Plan class
    /// This houses those Diet Plans which this Meal Plan is assigned to
    /// </summary>
    public class MealPlanAssignedDietPlan
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanAssignedDietPlan"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanAssignedDietPlan()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Meal Plan Diet Plan ID
        /// </summary>
        [Key]
        [DisplayName("MealPlanDietPlanId")]
        public int MealPlanDietPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [ForeignKey("MealPlan")]
        [DisplayName("MealPlanId")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Diet Plan ID
        /// </summary>
        [ForeignKey("DietPlan")]
        [DisplayName("DietPlanId")]
        public int DietPlanId { get; set; }

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
        //public virtual DietPlan DietPlans { get; set; }

        /// <summary>
        /// Gets or sets Diet Plan navigation property
        /// </summary>
        [ForeignKey("DietPlanID")]
        [InverseProperty("MealPlanAssignedDietPlans")]
        public virtual DietPlan DietPlan { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan navigation property
        /// </summary>
        [ForeignKey("MealPlanID")]
        [InverseProperty("MealPlanAssignedDietPlans")]
        public virtual MealPlan MealPlan { get; set; }
    }
}
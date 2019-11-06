//-----------------------------------------------------------------------
// <copyright file="MealPlanAssignedDietPlan.cs" company="University of Memphis">
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
    /// Meal Plan Diet Plan class
    /// This houses those Diet Plans which this Meal Plan is assigned to
    /// </summary>
    public class MealPlanAssignedDietPlanViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanAssignedDietPlan"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanAssignedDietPlanViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the Meal Plan Diet Plan ID
        /// </summary>
        [DisplayName("MealPlanDietPlanId")]
        public int MealPlanDietPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [DisplayName("MealPlanId")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Diet Plan ID
        /// </summary>
        [DisplayName("DietPlanId")]
        public int DietPlanId { get; set; }

        [DisplayName("Diet Plan")]
        public string DietPlanDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the date and time the record was created
        /// </summary>
        [DisplayName("Create Timestamp")]
        public DateTime Created { get; set; }
    }
}
//-----------------------------------------------------------------------
// <copyright file="DietPlan.cs" company="University of Memphis">
//     Copyright (c) University of Memphis All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EatsClickIt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Diet Plan class
    /// This houses Diet Plans
    /// </summary>
    public class DietPlan
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DietPlan"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public DietPlan()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Diet Plan ID
        /// </summary>
        [Key]
        [DisplayName("Diet Plan ID")]
        public int DietPlanId { get; set; }

        /// <summary>
        /// Gets or sets Diet Plan Description
        /// </summary>
        [Required]
        [DisplayName("Description")]
        [StringLength(256, MinimumLength = 1)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the date and time the record was created
        /// </summary>
        [ScaffoldColumn(false)]
        [DisplayName("Create Timestamp")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets Diet Plans which Meal Plan belong to
        /// </summary>
        [InverseProperty("DietPlan")]
        public virtual ICollection<MealPlanAssignedDietPlan> MealPlanAssignedDietPlans { get; set; }
    }
}
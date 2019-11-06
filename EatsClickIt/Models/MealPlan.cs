//-----------------------------------------------------------------------
// <copyright file="MealPlan.cs" company="University of Memphis">
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
    /// Meal Plan class
    /// This houses Meal Plans (component of a Diet Plan)
    /// </summary>
    public class MealPlan
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlan"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlan()
        {
            this.Active = true;
            Preparations = new HashSet<Preparation>();
        }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [Key]
        [DisplayName("Meal Plan ID")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan Description
        /// </summary>
        [Required]
        [DisplayName("Description")]
        [StringLength(1024, MinimumLength = 1)]
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

        /// <summary>
        /// Gets or sets Preparation Instructions for the Meal Plan
        /// </summary>
        public virtual ICollection<Preparation> Preparations { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan Categories which this Meal Plan belongs to
        /// </summary>
        [InverseProperty("MealPlan")]
        public virtual ICollection<MealPlanAssignedCategory> MealPlanAssignedCategories { get; set; }

        /// <summary>
        /// Gets or sets Diet Plans which this Meal Plan belongs to
        /// </summary>
        [InverseProperty("MealPlan")]
        public virtual ICollection<MealPlanAssignedDietPlan> MealPlanAssignedDietPlans { get; set; }

        /// <summary>
        /// Gets or sets the Dishes associated with this Meal Plan
        /// </summary>
        [InverseProperty("MealPlan")]
        public virtual ICollection<MealPlanAssignedDish> MealPlanAssignedDishes { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan Ingredients associated with this Meal Plan
        /// </summary>
        [InverseProperty("MealPlan")]
        public virtual ICollection<MealPlanAssignedIngredient> MealPlanAssignedIngredients { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan Nutrients associated with this Meal Plan
        /// </summary>
        [InverseProperty("MealPlan")]
        public virtual ICollection<MealPlanAssignedNutrient> MealPlanAssignedNutrients { get; set; }
    }
}
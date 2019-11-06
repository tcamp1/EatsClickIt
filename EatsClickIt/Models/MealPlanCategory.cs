//-----------------------------------------------------------------------
// <copyright file="MealPlanCategory.cs" company="University of Memphis">
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
    /// Meal Plan Category class
    /// This houses Meal Plan Categories
    /// </summary>
    public class MealPlanCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanCategory"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanCategory()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Meal Plan Category ID
        /// </summary>
        [Key]
        [DisplayName("Meal Plan Category ID")]
        public int MealPlanCategoryId { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan Category Description
        /// </summary>
        [Required]
        [DisplayName("Category")]
        [StringLength(256, MinimumLength = 1)]
        public string Description { get; set; }

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
        /// Gets or sets Meal Plan Categories which this Meal Plan belongs to
        /// </summary>
        [InverseProperty("MealPlanCategory")]
        public virtual ICollection<MealPlanAssignedCategory> MealPlanAssignedCategories { get; set; }
    }
}
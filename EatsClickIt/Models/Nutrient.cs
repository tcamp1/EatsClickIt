//-----------------------------------------------------------------------
// <copyright file="Nutrient.cs" company="University of Memphis">
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
    /// Nutrition class
    /// This houses nutrients
    /// </summary>
    public class Nutrient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Nutrient"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public Nutrient()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Nutritient ID
        /// </summary>
        [Key]
        [DisplayName("Nutritient ID")]
        public int NutritientId { get; set; }

        /// <summary>
        /// Gets or sets Nutrient Description
        /// </summary>
        [Required]
        [DisplayName("Nutrient")]
        [StringLength(50, MinimumLength = 1)]
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
        /// Gets or sets Diet Plans which Meal Plan belong to
        /// </summary>
        [InverseProperty("Nutrient")]
        public virtual ICollection<MealPlanAssignedNutrient> MealPlanAssignedNutrients { get; set; }
    }
}
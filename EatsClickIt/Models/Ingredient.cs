//-----------------------------------------------------------------------
// <copyright file="Ingredient.cs" company="University of Memphis">
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
    /// Ingredient class
    /// This houses Ingredients
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public Ingredient()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Ingredient ID
        /// </summary>
        [Key]
        [DisplayName("Ingredient ID")]
        public int IngredientId { get; set; }

        /// <summary>
        /// Gets or sets Ingredient Description
        /// </summary>
        [Required]
        [DisplayName("Ingredient")]
        [StringLength(50, MinimumLength = 1)]
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
        /// Gets or sets Ingredients which Meal Plan belong to
        /// </summary>
        [InverseProperty("Ingredient")]
        public virtual ICollection<MealPlanAssignedIngredient> MealPlanAssignedIngredients { get; set; }
    }
}
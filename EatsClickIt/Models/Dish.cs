//-----------------------------------------------------------------------
// <copyright file="Dish.cs" company="University of Memphis">
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
    /// Dish class
    /// This houses Dishes (component of a meal)
    /// </summary>
    public class Dish
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dish"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public Dish()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Dish ID
        /// </summary>
        [Key]
        [DisplayName("Dish ID")]
        public int DishId { get; set; }

        /// <summary>
        /// Gets or sets Dish Description
        /// </summary>
        [Required]
        [DisplayName("Description")]
        [StringLength(512, MinimumLength = 1)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Path for the photo
        /// </summary>
        [DisplayName("Photo file path")]
        [StringLength(512, MinimumLength = 1)]
        public string PhotoFilePath { get; set; }

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
        [InverseProperty("Dish")]
        public virtual ICollection<MealPlanAssignedDish> MealPlanAssignedDishes { get; set; }
    }
}
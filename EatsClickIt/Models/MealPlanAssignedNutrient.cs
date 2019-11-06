//-----------------------------------------------------------------------
// <copyright file="MealPlanAssignedNutrient.cs" company="University of Memphis">
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
    /// Meal Plan Assigned Nutritient class
    /// This houses Nutrients assigned to a Meal Plan
    /// </summary>
    public class MealPlanAssignedNutrient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MealPlanAssignedNutrient"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public MealPlanAssignedNutrient()
        {
            this.Active = true;
            this.Quantity = 0;
        }

        /// <summary>
        /// Gets or sets the Nutrition ID
        /// </summary>
        [Key]
        [DisplayName("Meal Plan Assigned Nutritient ID")]
        public int MealPlanAssignedNutrientId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [ForeignKey("MealPlan")]
        [DisplayName("Meal Plan ID")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Nutritient ID
        /// </summary>
        [ForeignKey("Nutrient")]
        [DisplayName("Nutritient ID")]
        public int NutritientId { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        [DisplayName("Quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Unit of Measure ID
        /// </summary>
        [ForeignKey("Uom")]
        [DisplayName("UOM ID")]
        public int UomId { get; set; }

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
        /// Gets or sets Unit of Measure navigation property
        /// </summary>
        public virtual Uom Uom { get; set; }

        /// <summary>
        /// Gets or sets Nutrient navigation property
        /// </summary>
        //public virtual Nutrient Nutrients { get; set; }

        /// <summary>
        /// Gets or sets Diet Plan navigation property
        /// </summary>
        [ForeignKey("NutrientID")]
        [InverseProperty("MealPlanAssignedNutrients")]
        public virtual Nutrient Nutrient { get; set; }

        /// <summary>
        /// Gets or sets Meal Plan navigation property
        /// </summary>
        [ForeignKey("MealPlanID")]
        [InverseProperty("MealPlanAssignedNutrients")]
        public virtual MealPlan MealPlan { get; set; }
    }
}
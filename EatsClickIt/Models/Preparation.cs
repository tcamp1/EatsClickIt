//-----------------------------------------------------------------------
// <copyright file="Preparation.cs" company="University of Memphis">
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
    /// Preparation class
    /// This houses the Preparation Instruction
    /// </summary>
    public class Preparation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Preparation"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public Preparation()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Preparation Instruction ID
        /// </summary>
        [Key]
        [ScaffoldColumn(false)]
        [DisplayName("Preparation ID")]
        public int PreparationId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
        [ForeignKey("MealPlan")]
        [DisplayName("Meal Plan ID")]
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets the Sequence Number
        /// </summary>
        [DisplayName("Sequence")]
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the Preparation Instruction
        /// </summary>
        [Required]
        [DisplayName("Instructions")]
        [StringLength(4086, MinimumLength = 1)]
        public string Instruction { get; set; }

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


        public virtual MealPlan MealPlan { get; set; }
    }
}
//-----------------------------------------------------------------------
// <copyright file="PreparationViewModel.cs" company="University of Memphis">
//     Copyright (c) University of Memphis All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EatsClickIt.ViewModels
{
    using System.ComponentModel;

    /// <summary>
    /// Preparation class
    /// This houses the Preparation Instruction
    /// </summary>
    public class PreparationViewModel
    {
        public PreparationViewModel()
        {
            PreparationId = -1;
            Active = true;
        }

        /// <summary>
        /// Gets or sets the Preparation Instruction ID
        /// </summary>
        [DisplayName("Preparation ID")]
        public int PreparationId { get; set; }

        /// <summary>
        /// Gets or sets the Meal Plan ID
        /// </summary>
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
        [DisplayName("Instructions")]
        public string Instruction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }
    }
}
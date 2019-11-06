//-----------------------------------------------------------------------
// <copyright file="Nutrient.cs" company="University of Memphis">
//     Copyright (c) University of Memphis All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EatsClickIt.ViewModels
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using EatsClickIt.Models;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Nutrition class
    /// This houses nutrients
    /// </summary>
    public class NutrientViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Nutrient"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public NutrientViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the Nutritient ID
        /// </summary>
        [DisplayName("Nutritient ID")]
        public int NutrientId { get; set; }

        /// <summary>
        /// Gets or sets Nutrient Description
        /// </summary>
        [DisplayName("Nutrient")]
        [StringLength(50, MinimumLength = 1)]
        public string Description { get; set; }

        public IEnumerable<NutrientViewModel> GetDropDownList()
        {
            var dbContext = new ApplicationDbContext();
            List<NutrientViewModel> nutrientViewModel = new List<NutrientViewModel>();

            nutrientViewModel = dbContext.Nutrients.AsNoTracking().Select(x =>
                                    new NutrientViewModel
                                    {
                                        NutrientId = x.NutritientId,
                                        Description = x.Description,
                                    }).ToList();

            return nutrientViewModel;
        }
    }
}
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
    public class UomViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Nutrient"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public UomViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the Nutritient ID
        /// </summary>
        [DisplayName("Uom ID")]
        public int UomId { get; set; }

        /// <summary>
        /// Gets or sets Nutrient Description
        /// </summary>
        [DisplayName("UOM")]
        [StringLength(50, MinimumLength = 1)]
        public string UofM { get; set; }

        public IEnumerable<UomViewModel> GetDropDownList()
        {
            var dbContext = new ApplicationDbContext();
            List<UomViewModel> uomViewModel = new List<UomViewModel>();

            uomViewModel = dbContext.Uoms.AsNoTracking().Select(x =>
                                    new UomViewModel
                                    {
                                        UomId = x.UomId,
                                        UofM = x.UofM,
                                    }).ToList();

            return uomViewModel;
        }
    }
}
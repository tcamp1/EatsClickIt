//-----------------------------------------------------------------------
// <copyright file="Dish.cs" company="University of Memphis">
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
    /// Dish class
    /// This houses Dishes (component of a meal)
    /// </summary>
    public class DishViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dish"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public DishViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the Dish ID
        /// </summary>
        [DisplayName("Dish ID")]
        public int DishId { get; set; }

        /// <summary>
        /// Gets or sets Dish Description
        /// </summary>
        [Required]
        [DisplayName("Description")]
        [StringLength(512, MinimumLength = 1)]
        public string Description { get; set; }

        public IEnumerable<DishViewModel> GetDropDownList()
        {
            var dbContext = new ApplicationDbContext();
            List<DishViewModel> dishViewModel = new List<DishViewModel>();

            dishViewModel = dbContext.Dishes.AsNoTracking().Select(x =>
                                    new DishViewModel
                                    {
                                        DishId = x.DishId,
                                        Description = x.Description,
                                    }).ToList();

            return dishViewModel;
        }
    }
}
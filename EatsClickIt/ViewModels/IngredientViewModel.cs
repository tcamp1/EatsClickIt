//-----------------------------------------------------------------------
// <copyright file="Ingredient.cs" company="University of Memphis">
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
    /// Ingredient class
    /// This houses Ingredients
    /// </summary>
    public class IngredientViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public IngredientViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the Ingredient ID
        /// </summary>
        [DisplayName("Ingredient ID")]
        public int IngredientId { get; set; }

        /// <summary>
        /// Gets or sets Ingredient Description
        /// </summary>
        [DisplayName("Ingredient")]
        [StringLength(50, MinimumLength = 1)]
        public string Description { get; set; }

        public IEnumerable<IngredientViewModel> GetDropDownList()
        {
            var dbContext = new ApplicationDbContext();
            List<IngredientViewModel> ingredientViewModel = new List<IngredientViewModel>();

            ingredientViewModel = dbContext.Ingredients.AsNoTracking().Select(x =>
                                    new IngredientViewModel
                                    {
                                        IngredientId = x.IngredientId,
                                        Description = x.Description,
                                    }).ToList();

            ingredientViewModel.Insert(0, new IngredientViewModel { IngredientId = -1, Description = "[Choose Ingredient]" });
            return ingredientViewModel;
        }
    }
}
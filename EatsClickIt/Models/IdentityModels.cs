using EatsClickIt.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EatsClickIt.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

    public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<EatsClickIt.Models.Uom> Uoms { get; set; }

        public System.Data.Entity.DbSet<EatsClickIt.Models.DietPlan> DietPlans { get; set; }

        public System.Data.Entity.DbSet<EatsClickIt.Models.Dish> Dishes { get; set; }

        public System.Data.Entity.DbSet<EatsClickIt.Models.Ingredient> Ingredients { get; set; }

        public System.Data.Entity.DbSet<EatsClickIt.Models.MealPlan> MealPlans { get; set; }
        public System.Data.Entity.DbSet<EatsClickIt.Models.Preparation> Preparations { get; set; }
        public System.Data.Entity.DbSet<EatsClickIt.Models.MealPlanCategory> MealPlanCategories { get; set; }
        public System.Data.Entity.DbSet<EatsClickIt.Models.MealPlanAssignedCategory> MealPlanAssignedCategories { get; set; }
        public System.Data.Entity.DbSet<EatsClickIt.Models.MealPlanAssignedDietPlan> MealPlanAssignedDietPlans { get; set; }
        public System.Data.Entity.DbSet<EatsClickIt.Models.Nutrient> Nutrients { get; set; }
        public System.Data.Entity.DbSet<EatsClickIt.Models.MealPlanAssignedNutrient> MealPlanAssignedNutrients { get; set; }
        public System.Data.Entity.DbSet<EatsClickIt.Models.MealPlanAssignedIngredient> MealPlanAssignedIngredients { get; set; }
        public System.Data.Entity.DbSet<EatsClickIt.Models.MealPlanAssignedDish> MealPlanAssignedDishes { get; set; }
    }
}
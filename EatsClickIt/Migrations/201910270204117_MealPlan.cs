namespace EatsClickIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MealPlan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MealPlanAssignedDietPlans",
                c => new
                    {
                        MealPlanDietPlanId = c.Int(nullable: false, identity: true),
                        MealPlanId = c.Int(nullable: false),
                        DietPlanId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.MealPlanDietPlanId)
                .ForeignKey("dbo.MealPlans", t => t.MealPlanId, cascadeDelete: true)
                .ForeignKey("dbo.DietPlans", t => t.DietPlanId, cascadeDelete: true)
                .Index(t => t.MealPlanId)
                .Index(t => t.DietPlanId);
            
            CreateTable(
                "dbo.MealPlans",
                c => new
                    {
                        MealPlanId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 1024),
                        PhotoFilePath = c.String(nullable: false, maxLength: 512),
                        PrepTime = c.Int(nullable: false),
                        PrepTimeUnit = c.String(nullable: false),
                        CostPerServing = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.MealPlanId);
            
            CreateTable(
                "dbo.MealPlanAssignedCategories",
                c => new
                    {
                        MealPlanAssignedCategoryId = c.Int(nullable: false, identity: true),
                        MealPlanId = c.Int(nullable: false),
                        MealPlanCategoryId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.MealPlanAssignedCategoryId)
                .ForeignKey("dbo.MealPlanCategories", t => t.MealPlanCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.MealPlans", t => t.MealPlanId, cascadeDelete: true)
                .Index(t => t.MealPlanId)
                .Index(t => t.MealPlanCategoryId);
            
            CreateTable(
                "dbo.MealPlanCategories",
                c => new
                    {
                        MealPlanCategoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 256),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.MealPlanCategoryId);
            
            CreateTable(
                "dbo.MealPlanAssignedDishes",
                c => new
                    {
                        MealPlanAssignedDishId = c.Int(nullable: false, identity: true),
                        MealPlanId = c.Int(nullable: false),
                        DishId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.MealPlanAssignedDishId)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.MealPlans", t => t.MealPlanId, cascadeDelete: true)
                .Index(t => t.MealPlanId)
                .Index(t => t.DishId);
            
            CreateTable(
                "dbo.MealPlanAssignedIngredients",
                c => new
                    {
                        MealPlanAssignedIngredientId = c.Int(nullable: false, identity: true),
                        MealPlanId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UomId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                        Ingredients_IngredientId = c.Int(),
                    })
                .PrimaryKey(t => t.MealPlanAssignedIngredientId)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredients_IngredientId)
                .ForeignKey("dbo.Uoms", t => t.UomId, cascadeDelete: true)
                .ForeignKey("dbo.MealPlans", t => t.MealPlanId, cascadeDelete: true)
                .Index(t => t.MealPlanId)
                .Index(t => t.IngredientId)
                .Index(t => t.UomId)
                .Index(t => t.Ingredients_IngredientId);
            
            CreateTable(
                "dbo.MealPlanAssignedNutrients",
                c => new
                    {
                        MealPlanAssignedNutrientId = c.Int(nullable: false, identity: true),
                        MealPlanId = c.Int(nullable: false),
                        NutritientId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UomId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.MealPlanAssignedNutrientId)
                .ForeignKey("dbo.Nutrients", t => t.NutritientId, cascadeDelete: true)
                .ForeignKey("dbo.Uoms", t => t.UomId, cascadeDelete: true)
                .ForeignKey("dbo.MealPlans", t => t.MealPlanId, cascadeDelete: true)
                .Index(t => t.MealPlanId)
                .Index(t => t.NutritientId)
                .Index(t => t.UomId);
            
            CreateTable(
                "dbo.Nutrients",
                c => new
                    {
                        NutritientId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.NutritientId);
            
            CreateTable(
                "dbo.Preparations",
                c => new
                    {
                        PreparationId = c.Int(nullable: false, identity: true),
                        MealPlanId = c.Int(nullable: false),
                        Sequence = c.Int(nullable: false),
                        Instruction = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.PreparationId)
                .ForeignKey("dbo.MealPlans", t => t.MealPlanId, cascadeDelete: true)
                .Index(t => t.MealPlanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealPlanAssignedDietPlans", "DietPlanId", "dbo.DietPlans");
            DropForeignKey("dbo.Preparations", "MealPlanId", "dbo.MealPlans");
            DropForeignKey("dbo.MealPlanAssignedNutrients", "MealPlanId", "dbo.MealPlans");
            DropForeignKey("dbo.MealPlanAssignedNutrients", "UomId", "dbo.Uoms");
            DropForeignKey("dbo.MealPlanAssignedNutrients", "NutritientId", "dbo.Nutrients");
            DropForeignKey("dbo.MealPlanAssignedIngredients", "MealPlanId", "dbo.MealPlans");
            DropForeignKey("dbo.MealPlanAssignedIngredients", "UomId", "dbo.Uoms");
            DropForeignKey("dbo.MealPlanAssignedIngredients", "Ingredients_IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.MealPlanAssignedIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.MealPlanAssignedDishes", "MealPlanId", "dbo.MealPlans");
            DropForeignKey("dbo.MealPlanAssignedDishes", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.MealPlanAssignedDietPlans", "MealPlanId", "dbo.MealPlans");
            DropForeignKey("dbo.MealPlanAssignedCategories", "MealPlanId", "dbo.MealPlans");
            DropForeignKey("dbo.MealPlanAssignedCategories", "MealPlanCategoryId", "dbo.MealPlanCategories");
            DropIndex("dbo.Preparations", new[] { "MealPlanId" });
            DropIndex("dbo.MealPlanAssignedNutrients", new[] { "UomId" });
            DropIndex("dbo.MealPlanAssignedNutrients", new[] { "NutritientId" });
            DropIndex("dbo.MealPlanAssignedNutrients", new[] { "MealPlanId" });
            DropIndex("dbo.MealPlanAssignedIngredients", new[] { "Ingredients_IngredientId" });
            DropIndex("dbo.MealPlanAssignedIngredients", new[] { "UomId" });
            DropIndex("dbo.MealPlanAssignedIngredients", new[] { "IngredientId" });
            DropIndex("dbo.MealPlanAssignedIngredients", new[] { "MealPlanId" });
            DropIndex("dbo.MealPlanAssignedDishes", new[] { "DishId" });
            DropIndex("dbo.MealPlanAssignedDishes", new[] { "MealPlanId" });
            DropIndex("dbo.MealPlanAssignedCategories", new[] { "MealPlanCategoryId" });
            DropIndex("dbo.MealPlanAssignedCategories", new[] { "MealPlanId" });
            DropIndex("dbo.MealPlanAssignedDietPlans", new[] { "DietPlanId" });
            DropIndex("dbo.MealPlanAssignedDietPlans", new[] { "MealPlanId" });
            DropTable("dbo.Preparations");
            DropTable("dbo.Nutrients");
            DropTable("dbo.MealPlanAssignedNutrients");
            DropTable("dbo.MealPlanAssignedIngredients");
            DropTable("dbo.MealPlanAssignedDishes");
            DropTable("dbo.MealPlanCategories");
            DropTable("dbo.MealPlanAssignedCategories");
            DropTable("dbo.MealPlans");
            DropTable("dbo.MealPlanAssignedDietPlans");
        }
    }
}

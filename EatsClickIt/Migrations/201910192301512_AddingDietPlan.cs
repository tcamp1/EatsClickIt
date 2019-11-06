namespace EatsClickIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDietPlan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietPlans",
                c => new
                    {
                        DietPlanId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 256),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.DietPlanId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DietPlans");
        }
    }
}

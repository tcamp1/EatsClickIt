namespace EatsClickIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MealPlans", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MealPlans", "Created", c => c.DateTime());
        }
    }
}

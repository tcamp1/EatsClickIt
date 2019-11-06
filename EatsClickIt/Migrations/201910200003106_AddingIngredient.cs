namespace EatsClickIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIngredient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.IngredientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ingredients");
        }
    }
}

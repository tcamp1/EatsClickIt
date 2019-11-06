namespace EatsClickIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDish : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        DishId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 512),
                        PhotoFilePath = c.String(nullable: false, maxLength: 512),
                        Active = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.DishId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dishes");
        }
    }
}

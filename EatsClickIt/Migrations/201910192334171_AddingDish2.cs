namespace EatsClickIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDish2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dishes", "PhotoFilePath", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dishes", "PhotoFilePath", c => c.String(nullable: false, maxLength: 512));
        }
    }
}

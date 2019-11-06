namespace EatsClickIt.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EatsClickIt.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EatsClickIt.Models.ApplicationDbContext context)
        {

            // context.Uoms.AddOrUpdate();
            //context.U.AddOrUpdate(x => x.Id,
            //        new Author() { Id = 1, Name = "Jane Austen" },
            //        new Author() { Id = 2, Name = "Charles Dickens" },
            //        new Author() { Id = 3, Name = "Miguel de Cervantes" }
            //        );
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

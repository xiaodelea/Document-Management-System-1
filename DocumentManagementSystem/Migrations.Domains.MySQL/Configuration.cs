namespace DocumentManagementSystem.Migrations.Domains.MySQL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DocumentManagementSystem.Models.Domains.MySQL.Entities.DMsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations.Domains.MySQL";
        }

        protected override void Seed(DocumentManagementSystem.Models.Domains.MySQL.Entities.DMsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

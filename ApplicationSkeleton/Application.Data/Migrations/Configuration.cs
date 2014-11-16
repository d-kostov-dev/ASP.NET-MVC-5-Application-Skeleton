namespace Application.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Application.Data.Migrations.Seeders;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            IdentitySeeder.Seed(context);
            InfoPageSeeder.Seed(context);
            CategorySeeder.Seed(context);
            CountrySeeder.Seed(context);

            // Just in case i don't save in any of the seeders
            context.SaveChanges();
        }
    }
}

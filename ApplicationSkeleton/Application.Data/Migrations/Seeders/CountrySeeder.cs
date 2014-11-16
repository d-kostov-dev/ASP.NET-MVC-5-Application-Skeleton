namespace Application.Data.Migrations.Seeders
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Application.Models;

    public class CountrySeeder
    {
        public static void Seed(ApplicationDbContext databaseContext)
        {
            if (!databaseContext.Countries.Any())
            {
                var countryNames = new string[]
                {
                    "Bulgaria",
                    "Germany",
                    "Italy",
                    "France",
                    "Spain",
                };

                for (int i = 0; i < countryNames.Length; i++)
                {
                    var currentItem = new Country()
                    {
                        Id = i + 1,
                        Name = countryNames[i],
                        CreatedOn = DateTime.Now,
                    };

                    databaseContext.Countries.AddOrUpdate(currentItem);
                }

                databaseContext.SaveChanges();
            }
        }
    }
}

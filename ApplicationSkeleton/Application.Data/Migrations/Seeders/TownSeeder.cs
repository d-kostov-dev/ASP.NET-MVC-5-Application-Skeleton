namespace Application.Data.Migrations.Seeders
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Application.Models;

    public class TownSeeder
    {
        public static void Seed(ApplicationDbContext databaseContext)
        {
            if (!databaseContext.Towns.Any())
            {
                var townNames = new string[]
                {
                    "Sofia",
                    "Plovdiv",
                    "Varna",
                    "Bourgas",
                    "Ruse",
                };

                var countryId = databaseContext.Countries.Where(x => x.Name == "Bulgaria").FirstOrDefault().Id;

                for (int i = 0; i < townNames.Length; i++)
                {
                    var currentItem = new Town()
                    {
                        Id = i + 1,
                        Name = townNames[i],
                        CountryId = countryId,
                        CreatedOn = DateTime.Now,
                    };

                    databaseContext.Towns.AddOrUpdate(currentItem);
                }

                databaseContext.SaveChanges();
            }
        }
    }
}

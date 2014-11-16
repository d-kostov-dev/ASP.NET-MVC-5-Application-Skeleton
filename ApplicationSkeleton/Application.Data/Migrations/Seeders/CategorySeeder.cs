namespace Application.Data.Migrations.Seeders
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Application.Models;

    public class CategorySeeder
    {
        public static void Seed(ApplicationDbContext databaseContext)
        {
            if (!databaseContext.Categories.Any())
            {
                var categoriesNames = new string[]
                {
                    "Sports",
                    "Books",
                    "Financial",
                    "Health",
                    "Gardening",
                    "Toys",
                    "Clothing",
                    "Automotive",
                    "Art",
                    "Internet",
                    "Games",
                    "Phones",
                    "Computers",
                    "Electronics",
                    "Business",
                    "News",
                    "Shopping",
                    "Education",
                    "Food",
                    "Travel",
                };

                for (int i = 0; i < categoriesNames.Length; i++)
                {
                    var currentItem = new Category()
                    {
                        Id = i + 1,
                        Name = categoriesNames[i],
                        CreatedOn = DateTime.Now,
                    };

                    databaseContext.Categories.AddOrUpdate(currentItem);
                }

                databaseContext.SaveChanges();
            }
        }
    }
}

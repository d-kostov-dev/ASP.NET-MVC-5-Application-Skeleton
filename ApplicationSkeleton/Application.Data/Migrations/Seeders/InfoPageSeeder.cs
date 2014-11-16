namespace Application.Data.Migrations.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Application.Models;
    
    public class InfoPageSeeder
    {
        private const string DefaultContentText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

        public static void Seed(ApplicationDbContext databaseContext)
        {
            if (!databaseContext.InfoPages.Any())
            {
                var pagesList = new List<InfoPage>()
                {
                    new InfoPage()
                    {
                        SeoUrl = "AboutUs",
                        Title = "About Us",
                    },
                    new InfoPage()
                    {
                        SeoUrl = "FAQ",
                        Title = "FAQ",
                    },
                    new InfoPage()
                    {
                        SeoUrl = "Contacts",
                        Title = "Contact Us",
                    },
                };

                for (int i = 0; i < pagesList.Count; i++)
                {
                    var currentItem = pagesList[i];

                    currentItem.Id = i + 1;
                    currentItem.Content = DefaultContentText;
                    currentItem.CreatedOn = DateTime.Now;

                    databaseContext.InfoPages.AddOrUpdate(currentItem);
                }

                databaseContext.SaveChanges();
            }
        }
    }
}

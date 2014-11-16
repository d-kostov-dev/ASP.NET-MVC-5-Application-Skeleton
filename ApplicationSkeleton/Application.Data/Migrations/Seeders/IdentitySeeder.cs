namespace Application.Data.Migrations.Seeders
{
    using System;
    using System.Linq;

    using Application.Common;
    using Application.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class IdentitySeeder
    {
        public static void Seed(ApplicationDbContext databaseContext)
        {
            if (!databaseContext.Roles.Any(r => r.Name == GlobalConstants.AdminRole))
            {
                var store = new RoleStore<IdentityRole>(databaseContext);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = GlobalConstants.AdminRole };

                manager.Create(role);
            }

            if (!databaseContext.Roles.Any(r => r.Name == GlobalConstants.UserRole))
            {
                var store = new RoleStore<IdentityRole>(databaseContext);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = GlobalConstants.UserRole };

                manager.Create(role);
            }

            if (!databaseContext.Users.Any(u => u.UserName == "admin@abv.bg"))
            {
                var store = new UserStore<ApplicationUser>(databaseContext);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser 
                { 
                    UserName = "admin@abv.bg", 
                    Email = "admin@abv.bg", 
                    CreatedOn = DateTime.Now,
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, GlobalConstants.AdminRole);
            }

            if (!databaseContext.Users.Any(u => u.UserName == "user@abv.bg"))
            {
                var store = new UserStore<ApplicationUser>(databaseContext);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser 
                { 
                    UserName = "user@abv.bg", 
                    Email = "user@abv.bg", 
                    CreatedOn = DateTime.Now,
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, GlobalConstants.UserRole);
            }

            databaseContext.SaveChanges();
        }
    }
}

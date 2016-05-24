namespace ChickenWinners.Migrations
{
    using ChickenWinners.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChickenWinners.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ChickenWinners.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var user = userManager.FindByEmail("lander45@hotmail.co.uk");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "lander45@hotmail.co.uk",
                    Email = "lander45@hotmail.co.uk"
                };
                userManager.Create(user, "Test123#");
            }

            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole
            {
                Name = "Admin"
            });
            context.SaveChanges();

            userManager.AddToRole(user.Id, "Admin");

            //  This method will be called after migrating to the latest version.
            //
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

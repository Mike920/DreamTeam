using System.Collections.Generic;
using DreamTeam.Models;

namespace DreamTeam.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DreamTeam.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }
       

        protected override void Seed(DreamTeam.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

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
            


            var roles = new TeamRole[]{
                new TeamRole() { Name = ".NET Developer"},
                new TeamRole() { Name = "Java Developer"},
                new TeamRole() { Name = "C++ Developer"},
                new TeamRole() { Name = "Designer"}
                };
            context.TeamRoles.AddOrUpdate(roles);


            var users = new ApplicationUser[]{
                new ApplicationUser() { Email = "test@mail.com",UserName = "Adam Kowalski",Country = "Poland"},
                new ApplicationUser() { Email = "test2@mail.com",UserName = "Mark Johnson",Country = "USA"},
                new ApplicationUser() { Email = "test3@mail.com",UserName = "Edmund Jungen",Country = "Germany"},
                new ApplicationUser() { Email = "test4@mail.com",UserName = "Noname",Country = "Poland"}
                };
            context.Users.AddOrUpdate(users);

            var projects = new Project[]
            {
                new Project{Name = "Mobile game",Description = "Loking for android developer and graphics designer",
                    Owner = users[0],TeamRoles = (new TeamRole[]{ roles[1],roles[3]}).ToList()},
                new Project{Name = "Desktop application",Description = "Loking for .Net developers",
                    Owner = users[1],TeamRoles = (new TeamRole[]{ roles[0],roles[0]}).ToList()},
                new Project{Name = "Web application",Description = "Loking for  graphics designer",
                    Owner = users[0],TeamRoles = (new TeamRole[]{ roles[3]}).ToList()}
            };
            context.Projects.AddOrUpdate(projects);
        }
    }
}

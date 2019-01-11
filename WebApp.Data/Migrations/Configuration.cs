namespace WebApp.Data.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using WebApp.Model.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Data.WebAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Data.WebAppDbContext context)
        {
			CreateUser(context);
		}

		private void CreateUser(WebAppDbContext context)
		{
			var manager = new UserManager<AppUser>(new UserStore<AppUser>(new WebAppDbContext()));
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new WebAppDbContext()));

			var user = new AppUser()
			{
				UserName = "Admin",
				Email = "admin@webapp.com",
				EmailConfirmed = true,
				BirthDay = Convert.ToDateTime("10/01/1993"),
				FullName = "Admin"

			};

			if (context.Users.Count(x => x.UserName == "Admin") == 0)
			{
				manager.Create(user, "123456$");
				if (!roleManager.Roles.Any())
				{
					roleManager.Create(new IdentityRole { Name = "Admin" });
					roleManager.Create(new IdentityRole { Name = "User" });
				}
				var adminUser = manager.FindByEmail("admin@webapp.com");
				manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
			}
		}
	}
}

using API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {

        public static void SeedUsers(UserManager<User> userManager
           , RoleManager<Role> roleManager)//DataContext _context
        {
            if (!roleManager.Roles.Any()) //!_context.Users.Any()
            {
                //var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                //var users = JsonConvert.DeserializeObject<List<User>>(userData);

                var roles = new List<Role>
                    {
                        new Role {Name = "Member"},
                        new Role {Name = "Admin"},
                        new Role {Name = "Moderator"},
                        new Role {Name = "VIP"},
                    };

                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role);
                }

              /*  foreach (var user in users)
                {
                    userManager.CreateAsync(user, "password");
                    userManager.AddToRoleAsync(user, "Member");
                }

                var adminUser = new User
                {
                    UserName = "Admin"
                };

                var result = userManager.CreateAsync(adminUser, "password").Result;

                if (result.Succeeded)
                {
                    var admin = userManager.FindByNameAsync("Admin").Result;
                    userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
                }*/
            }
        }

    }
}

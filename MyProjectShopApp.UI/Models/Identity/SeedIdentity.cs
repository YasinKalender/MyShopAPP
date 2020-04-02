using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MyProjectShopApp.UI.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectShopApp.UI.Models.Identity
{
    public static class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {

            var username = configuration["Data:Adminuser:username"];
            var email = configuration["Data:Adminuser:email"];
            var pass = configuration["Data:Adminuser:password"];
            var role = configuration["Data:Adminuser:role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));

                var user = new User()
                {
                    UserName = username,
                    Email = email,
                    FullName = "Admin User"


                };


                var result = await userManager.CreateAsync(user, pass);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }


            }




        }


    }
}

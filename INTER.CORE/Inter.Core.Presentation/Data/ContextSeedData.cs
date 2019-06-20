using Inter.Core.Presentation.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Inter.Core.Presentation.Data
{
    public static class ContextSeedData
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUserViewModel> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUserViewModel>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string userName = "Super Admin";
            string email = "caio1@gmail.com";
            string password = "Secret0107$";
            string role = "Admin";

            if (await userManager.FindByNameAsync(userName) == null)
            {
                // Create SuperAdmins role if it doesn't exist
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                // Create user account if it doesn't exist
                ApplicationUserViewModel user = new ApplicationUserViewModel
                {
                    UserName = userName,
                    Email = email
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                // Assign role to the user
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

        }
    }
}

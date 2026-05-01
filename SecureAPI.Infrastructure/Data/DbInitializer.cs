using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SecureAPI.Domain.Constants;
using SecureAPI.Domain.Entities;

namespace SecureAPI.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            // Create
            // Admin Roles
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));

            //User Roles
            if(!await roleManager.RoleExistsAsync(Roles.User))
                await roleManager.CreateAsync(new IdentityRole(Roles.User));

            // Create Admin User
            var adminEmail = "admin@secureapi.com";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if(adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "System Admin"

                };
                var result = await userManager.CreateAsync(user, "Admin@123");

                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                }
            }
        }
    }
}

using BookshopTheReader.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using TheReader.Infrastructure.Data.Models.Account;
using static TheReader.Infrastructure.Constants.ApplicaitonConstants;

namespace Bookshop___The_Reader.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var userManager = scopedServices.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scopedServices.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string email = "Admin@gmail.com";


            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
            {
                var role = new IdentityRole(AdminRole);
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync(email);

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, AdminRole);
                }
            }

        }
    }
}

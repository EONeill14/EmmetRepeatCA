using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmmetRepeatCA.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Pass123!";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDBContext context = app.ApplicationServices.
                CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDBContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                user.Email = "admin@example.com";
                user.PhoneNumber = "087-7777777";
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
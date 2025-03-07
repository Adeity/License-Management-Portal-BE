using DP_BE_LicensePortal.Context;
using DP_BE_LicensePortal.Model.database;
using Microsoft.AspNetCore.Identity;

namespace DP_BE_LicensePortal.Extensions;

public static class SeedExtensions
{
    public static async void ApplySeeds(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
        using MyDbContext context = serviceScope.ServiceProvider.GetService<MyDbContext>();
        
        await SeedRoles(serviceScope);
        await SeedInitialUser(serviceScope);
    }

    private static async Task SeedInitialUser(IServiceScope serviceScope)
    {
        var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

        string email = "p@p.com";
        string password = "Admin123!";
        if (await userManager.FindByEmailAsync("admin") == null)
        {
            var user = new User();
            user.UserName = email;
            user.Email = email;
            
            await userManager.CreateAsync(user, password);
            
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }

    private static async Task SeedRoles(IServiceScope serviceScope)
    {
        var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

        var roles = new[] { "Admin", "Reseller", "Customer" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                roleManager.CreateAsync(new IdentityRole(role)).Wait();
            }
        }
    }
    
}
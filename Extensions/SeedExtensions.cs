using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Extensions;

public static class SeedExtensions
{
    public static async void ApplySeeds(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
        using MyDbContext context = serviceScope.ServiceProvider.GetService<MyDbContext>();

        await SeedFromRawSql(context);
    }

    private static async Task SeedFromRawSql(MyDbContext context)
    {
        context.Database.EnsureCreated();

        try
        {
            string sql = await File.ReadAllTextAsync("./Extensions/seeds.sql");
            await context.Database.ExecuteSqlRawAsync(sql);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static async Task SeedInitialUser(IServiceScope serviceScope)
    {
        var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

        string password = "Admin123!";
        if (await userManager.FindByEmailAsync("admin@p.com") == null)
        {
            var adminUser = new User
            {
                UserName = "admin@p.com",
                Email = "admin@p.com"
            };
            await userManager.CreateAsync(adminUser, password);
            await userManager.AddToRoleAsync(adminUser, "Admin");

            var resellerUserOne = new User
            {
                UserName = "reseller1@p.com",
                Email = "reseller1@p.com"
            };
            await userManager.CreateAsync(resellerUserOne, password);
            await userManager.AddToRoleAsync(resellerUserOne, "Reseller");

            var resellerUserTwo = new User
            {
                UserName = "reseller2@p.com",
                Email = "reseller2@p.com"
            };
            await userManager.CreateAsync(resellerUserTwo, password);
            await userManager.AddToRoleAsync(resellerUserTwo, "Reseller");

            var resellerUserThree = new User
            {
                UserName = "reseller3@p.com",
                Email = "reseller3@p.com"
            };
            await userManager.CreateAsync(resellerUserThree, password);
            await userManager.AddToRoleAsync(resellerUserThree, "Reseller");

            var customerUserOne = new User
            {
                UserName = "customer1@p.com",
                Email = "customer1@p.com"
            };
            await userManager.CreateAsync(customerUserOne, password);
            await userManager.AddToRoleAsync(customerUserOne, "Customer");

            var customerUserTwo = new User
            {
                UserName = "customer2@p.com",
                Email = "customer2@p.com"
            };
            await userManager.CreateAsync(customerUserTwo, password);
            await userManager.AddToRoleAsync(customerUserTwo, "Customer");
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
using LicenseManagementPortal.Context;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
        using MyDbContext context = serviceScope.ServiceProvider.GetService<MyDbContext>();
        context.Database.Migrate();
    }

    public static void DeleteDatabase(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
        using MyDbContext context = serviceScope.ServiceProvider.GetService<MyDbContext>();
        context.Database.EnsureDeleted();
    }

}
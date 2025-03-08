using DP_BE_LicensePortal.Context;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Extensions;

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
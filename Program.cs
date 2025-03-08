
using System.Text;
using DP_BE_LicensePortal;
using DP_BE_LicensePortal.Context;
using DP_BE_LicensePortal.Extensions;
using DP_BE_LicensePortal.Model.database;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Repositories;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services;
using DP_BE_LicensePortal.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>()
    .AddApiEndpoints();

// Register repositories
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IOrganizationAccountRepository, OrganizationAccountRepository>();
builder.Services.AddScoped<IPackageDetailRepository, PackageDetailRepository>();
builder.Services.AddScoped<ISerialNumberDetailRepository, SerialNumberDetailRepository>();
builder.Services.AddScoped<SerialNumberRequestLogRepository>();
// // Register services
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IOrganizationAccountService, OrganizationAccountService>();
builder.Services.AddScoped<IPackageDetailService, PackageDetailService>();
builder.Services.AddScoped<ISerialNumberDetailService, SerialNumberDetailService>();
builder.Services.AddScoped<IResellerService, ResellerService>();
builder.Services.AddScoped<ISubscriptionItemService, SubscriptionItemService>();
builder.Services.AddScoped<ISubscriptionItemRepository, SubscriptionItemRepository>();
builder.Services.AddScoped<SerialNumberRequestLogService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builderCors => builderCors.WithOrigins("http://127.0.0.1:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.DeleteDatabase();
    // app.ApplyMigrations();
    // app.ApplySeeds();
}

var identityApis = app.MapIdentityApi<User>();
identityApis.AddEndpointFilter(async (context, next) =>
{
    if (context.HttpContext.Request.Path == "/register")
        return Results.Forbid();
    
    return await next(context);
});


app.MapGet("/weatherforecast", (HttpContext httpContext) =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = "asewsoem"
                })
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi()
    .RequireAuthorization();

// Use the CORS policy
app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();

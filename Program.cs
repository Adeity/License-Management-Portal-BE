using LicenseManagementPortal.Context;
using LicenseManagementPortal.Extensions;
using LicenseManagementPortal.Model.database;
using LicenseManagementPortal.Repositories;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services;
using LicenseManagementPortal.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext
builder.Services.AddDbContextFactory<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));

Console.WriteLine(builder.Configuration.GetConnectionString("MyDatabase"));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie("Identity.Application", options =>
{
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        },
        OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddUserManager<CustomUserManager>()
    .AddEntityFrameworkStores<MyDbContext>()
    .AddApiEndpoints();

// Register repositories
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IOrganizationAccountRepository, OrganizationAccountRepository>();
builder.Services.AddScoped<IPackageDetailRepository, PackageDetailRepository>();
builder.Services.AddScoped<ISerialNumberDetailRepository, SerialNumberDetailRepository>();
builder.Services.AddScoped<ISerialNumberRequestLogRepository, SerialNumberRequestLogRepository>();
builder.Services.AddScoped<IOrganizationTypeRepository, OrganizationTypeRepository>();
builder.Services.AddScoped<IInvoiceTypeRepository, InvoiceTypeRepository>();
builder.Services.AddScoped<IOrganizationContactRepository, OrganizationContactRepository>();
builder.Services.AddScoped<ISubscriptionItemRepository, SubscriptionItemRepository>();
builder.Services.AddScoped<IOrganizationPackageDetailsRepository, OrganizationPackageDetailsRepository>();
// Register services
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IOrganizationAccountService, OrganizationAccountService>();
builder.Services.AddScoped<IPackageDetailService, PackageDetailService>();
builder.Services.AddScoped<ISerialNumberDetailService, SerialNumberDetailService>();
builder.Services.AddScoped<IResellerService, ResellerService>();
builder.Services.AddScoped<ISubscriptionItemService, SubscriptionItemService>();
builder.Services.AddScoped<ISerialNumberRequestLogService, SerialNumberRequestLogService>();
builder.Services.AddScoped<IOrganizationContactService, OrganizationContactService>();
builder.Services.AddScoped<ILicenseActionsService, LicenseActionsService>();
builder.Services.AddScoped<IActivationServiceCaller, ActivationServiceCallerLocal>();
builder.Services.AddScoped<IOrganizationPackageDetailsService, OrganizationPackageDetailsService>();
builder.Services.AddScoped<ICustomUserManager, CustomUserManager>();
builder.Services.AddScoped<IMyDbContextProvider, MyDbContextProvider>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builderCors => builderCors.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
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

// Use the CORS policy
app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();

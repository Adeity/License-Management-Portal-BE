
using DP_BE_LicensePortal.Context;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Repositories;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services;
using DP_BE_LicensePortal.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IOrganizationAccountRepository, OrganizationAccountRepository>();
builder.Services.AddScoped<IPackageDetailRepository, PackageDetailRepository>();
builder.Services.AddScoped<ISerialNumberDetailRepository, SerialNumberDetailRepository>();
// // Register services
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IOrganizationAccountService, OrganizationAccountService>();
builder.Services.AddScoped<IPackageDetailService, PackageDetailService>();
builder.Services.AddScoped<ISerialNumberDetailService, SerialNumberDetailService>();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Use the CORS policy
app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();

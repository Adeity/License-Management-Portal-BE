using System.ComponentModel.DataAnnotations.Schema;
using LicenseManagementPortal.Model.Entities;
using Microsoft.AspNetCore.Identity;

namespace LicenseManagementPortal.Model.database;

public class User : IdentityUser
{
    [InverseProperty("LoginUser")]
    public OrganizationContact OrganizationContact { get; set; }
}
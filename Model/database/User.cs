using System.ComponentModel.DataAnnotations.Schema;
using DP_BE_LicensePortal.Model.Entities;
using Microsoft.AspNetCore.Identity;

namespace DP_BE_LicensePortal.Model.database;

public class User : IdentityUser
{
    [InverseProperty("LoginUser")]
    public OrganizationContact OrganizationContact { get; set; }
}
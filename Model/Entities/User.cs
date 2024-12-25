using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class User : IdentityUser<int>
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }
    public string PasswordHash { get; set; } = null!;
    public int? IsSmart { get; set; }
    public string? WindowsUserName { get; set; } 
    public virtual ICollection<OrganizationContact> OrganizationContacts { get; set; } = new List<OrganizationContact>();
}

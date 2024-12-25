using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class OrganizationType
{
    public DateTime UpdateDate { get; set; }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<OrganizationAccount> OrganizationAccounts { get; set; } = new List<OrganizationAccount>();
}

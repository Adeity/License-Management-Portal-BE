using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class OrganizationRole
{
    public string Name { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<OrganizationContact> OrganizationContacts { get; set; } = new List<OrganizationContact>();
}

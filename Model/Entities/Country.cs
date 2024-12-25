using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class Country
{
    public DateTime UpdateDate { get; set; }

    public int Id { get; set; }

    public int SelectOrder { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<OrganizationAddress> OrganizationAddresses { get; set; } = new List<OrganizationAddress>();
}

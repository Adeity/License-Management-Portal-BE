using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class OrganizationPackageDetail
{
    public int Id { get; set; }

    public int SerialNumbersCount { get; set; }

    public DateTime UpdateDate { get; set; }

    public int PackageDetailsId { get; set; }

    public int OrganizationAccountId { get; set; }

    public virtual OrganizationAccount OrganizationAccount { get; set; } = null!;

    public virtual PackageDetail PackageDetails { get; set; } = null!;
}

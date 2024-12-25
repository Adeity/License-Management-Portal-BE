using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class OrganizationAccount
{
    public string Name { get; set; } = null!;

    public int? ParentOrganizationId { get; set; }

    public string UserId { get; set; } = null!;

    public string? AccountId { get; set; }

    public int Id { get; set; }

    public int OrganizationTypeId { get; set; }

    public DateTime UpdateDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<OrganizationAccount> InverseParentOrganization { get; set; } = new List<OrganizationAccount>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OrganizationAddress> OrganizationAddresses { get; set; } = new List<OrganizationAddress>();

    public virtual ICollection<OrganizationContact> OrganizationContacts { get; set; } = new List<OrganizationContact>();

    public virtual ICollection<OrganizationPackageDetail> OrganizationPackageDetails { get; set; } = new List<OrganizationPackageDetail>();

    public virtual OrganizationType OrganizationType { get; set; } = null!;

    public virtual OrganizationAccount? ParentOrganization { get; set; }
}

using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class OrganizationAddress
{
    public string PostalCode { get; set; } = null!;

    public int Id { get; set; }

    public int AddressTypeId { get; set; }

    public int OrganizationAccountId { get; set; }

    public DateTime UpdateDate { get; set; }

    public string State { get; set; } = null!;

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string City { get; set; } = null!;

    public int CountryId { get; set; }

    public string Address { get; set; } = null!;

    public virtual AddressType AddressType { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual OrganizationAccount OrganizationAccount { get; set; } = null!;
}

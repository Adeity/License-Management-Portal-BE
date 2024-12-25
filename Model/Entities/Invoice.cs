using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class Invoice
{
    public int InvoiceTypeId { get; set; }

    public int Id { get; set; }

    public int OrganizationAccountId { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual InvoiceType InvoiceType { get; set; } = null!;

    public virtual OrganizationAccount OrganizationAccount { get; set; } = null!;
}

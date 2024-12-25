using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class InvoiceType
{
    public string Description { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string Name { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}

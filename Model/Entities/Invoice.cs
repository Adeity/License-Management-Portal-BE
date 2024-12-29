using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Model.Entities;

[Table("Invoice", Schema = "Reseller")]
[Index("InvoiceTypeId", Name = "IX_Invoice_InvoiceType")]
[Index("OrganizationAccountId", Name = "IX_Invoice_OrganizationAccount")]
public partial class Invoice
{
    [Key]
    public int Id { get; set; }

    public int OrganizationAccountId { get; set; }

    public int InvoiceTypeId { get; set; }

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [ForeignKey("InvoiceTypeId")]
    [InverseProperty("Invoices")]
    public virtual InvoiceType InvoiceType { get; set; } = null!;

    [ForeignKey("OrganizationAccountId")]
    [InverseProperty("Invoices")]
    public virtual OrganizationAccount OrganizationAccount { get; set; } = null!;

    [InverseProperty("Invoice")]
    public virtual ICollection<SubscriptionItem> SubscriptionItems { get; set; } = new List<SubscriptionItem>();
}

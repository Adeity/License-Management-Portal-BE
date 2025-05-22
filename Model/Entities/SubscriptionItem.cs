using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Model.Entities;

[Table("SubscriptionItem", Schema = "Reseller")]
public partial class SubscriptionItem
{
    [Key]
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int SerialNumberDetailsId { get; set; }

    public int EMailSentCount { get; set; }

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [ForeignKey("InvoiceId")]
    [InverseProperty("SubscriptionItems")]
    public virtual Invoice Invoice { get; set; } = null!;

    [ForeignKey("SerialNumberDetailsId")]
    [InverseProperty("SubscriptionItems")]
    public virtual SerialNumberDetail SerialNumberDetails { get; set; } = null!;
}

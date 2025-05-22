using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Model.Entities;

[Table("SerialNumberDetails", Schema = "Activation")]
public partial class SerialNumberDetail
{
    [Key]
    public int ID { get; set; }

    public int SerialNumberRequestLogID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string SerialNumber { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string AccountID { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Prefix { get; set; } = null!;

    [StringLength(50)]
    public string ProductNumber { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ExpirationDate { get; set; }

    public bool? IsTemp { get; set; }

    public bool IsValid { get; set; }

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LatestModificationDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ResellerCode { get; set; } = null!;

    [StringLength(50)]
    public string ResellerAccount { get; set; } = null!;

    [StringLength(50)]
    public string ResellerInvoice { get; set; } = null!;

    [StringLength(50)]
    public string ResellerInvoiceLastRenew { get; set; } = null!;

    [ForeignKey("SerialNumberRequestLogID")]
    [InverseProperty("SerialNumberDetails")]
    public virtual SerialNumberRequestLog SerialNumberRequestLog { get; set; } = null!;

    [InverseProperty("SerialNumberDetails")]
    public virtual ICollection<SubscriptionItem> SubscriptionItems { get; set; } = new List<SubscriptionItem>();
    public virtual ICollection<ActivationDetail> ActivationDetails { get; set; } = new List<ActivationDetail>();
    public virtual ICollection<ActivationStatusLog> ActivationStatusLogs { get; set; } = new List<ActivationStatusLog>();
}

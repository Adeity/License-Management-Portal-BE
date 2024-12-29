using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Model.Entities;

[Table("InvoiceType", Schema = "Reseller")]
[Index("Name", Name = "UQ_InvoiceType_Name", IsUnique = true)]
public partial class InvoiceType
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string Description { get; set; } = null!;

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [InverseProperty("InvoiceType")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}

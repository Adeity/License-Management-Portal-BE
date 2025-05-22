using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Model.Entities;

[Table("OrganizationPackageDetails", Schema = "Reseller")]
public partial class OrganizationPackageDetail
{
    [Key]
    public int Id { get; set; }

    public int OrganizationAccountId { get; set; }

    public int PackageDetailsId { get; set; }

    public int SerialNumbersCount { get; set; }

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [ForeignKey("OrganizationAccountId")]
    [InverseProperty("OrganizationPackageDetails")]
    public virtual OrganizationAccount OrganizationAccount { get; set; } = null!;

    [ForeignKey("PackageDetailsId")]
    [InverseProperty("OrganizationPackageDetails")]
    public virtual PackageDetail PackageDetails { get; set; } = null!;
}

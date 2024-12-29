using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Model.Entities;

[Table("PackageDetails", Schema = "Activation")]
public partial class PackageDetail
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    public string ProductNumber { get; set; } = null!;

    [StringLength(50)]
    public string ProductName { get; set; } = null!;

    public string Title { get; set; } = null!;

    [StringLength(10)]
    public string Prefix { get; set; } = null!;

    public bool? Legacy { get; set; }

    public bool? LegacyPlus { get; set; }

    public bool? Current { get; set; }

    public bool? Advanced { get; set; }

    public bool? Engineering { get; set; }

    public bool? Hybrid { get; set; }

    public int? Flags { get; set; }

    public int Subscription { get; set; }

    [StringLength(50)]
    public string? UserID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int RoleKeyId { get; set; }

    [InverseProperty("PackageDetails")]
    public virtual ICollection<OrganizationPackageDetail> OrganizationPackageDetails { get; set; } = new List<OrganizationPackageDetail>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Model.Entities;

[Table("OrganizationAccount", Schema = "Reseller")]
[Index("AccountID", Name = "IX_OrganizationAccount_Account")]
[Index("OrganizationTypeId", Name = "IX_OrganizationAccount_OrganizationType")]
[Index("ParentOrganizationId", Name = "IX_OrganizationAccount_ParentOrganizationId")]
[Index("Name", "ParentOrganizationId", Name = "UQ_OrganizationAccount_Name", IsUnique = true)]
public partial class OrganizationAccount
{
    [Key]
    public int Id { get; set; }

    public int OrganizationTypeId { get; set; }

    public int? ParentOrganizationId { get; set; }

    [StringLength(250)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string? AccountID { get; set; }

    public bool IsDeleted { get; set; }

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [InverseProperty("ParentOrganization")]
    public virtual ICollection<OrganizationAccount> InverseParentOrganization { get; set; } = new List<OrganizationAccount>();

    [InverseProperty("OrganizationAccount")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [InverseProperty("OrganizationAccount")]
    public virtual OrganizationAddress? OrganizationAddress { get; set; } = null!;

    [InverseProperty("OrganizationAccount")]
    public virtual ICollection<OrganizationContact> OrganizationContacts { get; set; } = new List<OrganizationContact>();

    [InverseProperty("OrganizationAccount")]
    public virtual ICollection<OrganizationPackageDetail> OrganizationPackageDetails { get; set; } = new List<OrganizationPackageDetail>();

    [ForeignKey("OrganizationTypeId")]
    [InverseProperty("OrganizationAccounts")]
    public virtual OrganizationType OrganizationType { get; set; } = null!;

    [ForeignKey("ParentOrganizationId")]
    [InverseProperty("InverseParentOrganization")]
    public virtual OrganizationAccount? ParentOrganization { get; set; }
}

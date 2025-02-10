using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Model.Entities;

[Table("OrganizationAddress", Schema = "Reseller")]
[Index("AddressTypeId", Name = "IX_OrganizationAddress_AddressType")]
[Index("CountryId", Name = "IX_OrganizationAddress_Country")]
[Index("OrganizationAccountId", Name = "IX_OrganizationAddress_OrganizationAccount")]
public partial class OrganizationAddress
{
    [Key]
    public int Id { get; set; }

    public int OrganizationAccountId { get; set; }

    public int AddressTypeId { get; set; }

    [StringLength(250)]
    public string Address { get; set; } = null!;

    [StringLength(250)]
    public string? Address2 { get; set; }

    [StringLength(250)]
    public string? Address3 { get; set; }

    [StringLength(250)]
    public string City { get; set; } = null!;

    [StringLength(250)]
    public string State { get; set; } = null!;

    public int CountryId { get; set; }

    [StringLength(50)]
    public string PostalCode { get; set; } = null!;

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [ForeignKey("AddressTypeId")]
    [InverseProperty("OrganizationAddresses")]
    public virtual AddressType AddressType { get; set; } = null!;

    [ForeignKey("CountryId")]
    [InverseProperty("OrganizationAddresses")]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey("OrganizationAccountId")]
    [InverseProperty("OrganizationAddress")]
    public virtual OrganizationAccount OrganizationAccount { get; set; } = null!;
}

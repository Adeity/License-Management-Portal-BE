using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Model.Entities;

[Table("ContactType", Schema = "Reseller")]
[Index("Name", Name = "UQ_ContactType_Name", IsUnique = true)]
public partial class ContactType
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(250)]
    public string Description { get; set; } = null!;

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [InverseProperty("ContactType")]
    public virtual ICollection<OrganizationContact> OrganizationContacts { get; set; } = new List<OrganizationContact>();
}

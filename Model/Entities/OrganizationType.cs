using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Model.Entities;

[Table("OrganizationType", Schema = "Reseller")]
public partial class OrganizationType
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

    [InverseProperty("OrganizationType")]
    public virtual ICollection<OrganizationAccount> OrganizationAccounts { get; set; } = new List<OrganizationAccount>();
}

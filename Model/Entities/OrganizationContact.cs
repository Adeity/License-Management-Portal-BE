using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DP_BE_LicensePortal.Model.database;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Model.Entities;

[Table("OrganizationContact", Schema = "Reseller")]
[Index("ContactTypeId", Name = "IX_OrganizationContact_ContactType")]
[Index("OrganizationAccountId", Name = "IX_OrganizationContact_OrganizationAccount")]
public partial class OrganizationContact
{
    [Key]
    public int Id { get; set; }

    public int OrganizationAccountId { get; set; }

    [StringLength(250)]
    public string FirstName { get; set; } = null!;

    [StringLength(250)]
    public string LastName { get; set; } = null!;

    public int OrganizationRoleId { get; set; }

    public int ContactTypeId { get; set; }

    [StringLength(250)]
    public string EMail { get; set; } = null!;

    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Login { get; set; }

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [ForeignKey("ContactTypeId")]
    [InverseProperty("OrganizationContacts")]
    public virtual ContactType ContactType { get; set; } = null!;

    [ForeignKey("OrganizationAccountId")]
    [InverseProperty("OrganizationContacts")]
    public virtual OrganizationAccount OrganizationAccount { get; set; } = null!;

    [ForeignKey("OrganizationRoleId")]
    [InverseProperty("OrganizationContacts")]
    public virtual OrganizationRole OrganizationRole { get; set; } = null!;
    
    [ForeignKey("LoginUserId")]
    public virtual User LoginUser { get; set; } = null!;
}

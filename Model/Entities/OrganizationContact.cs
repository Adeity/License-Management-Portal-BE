using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

public partial class OrganizationContact
{
    public int OrganizationRoleId { get; set; }

    public int? UserId { get; set; }

    public DateTime UpdateDate { get; set; }

    public int Id { get; set; }

    public int OrganizationAccountId { get; set; }

    public int ContactTypeId { get; set; }

    public virtual ContactType ContactType { get; set; } = null!;

    public virtual OrganizationAccount OrganizationAccount { get; set; } = null!;

    public virtual OrganizationRole OrganizationRole { get; set; } = null!;

    public virtual User? User { get; set; }
}

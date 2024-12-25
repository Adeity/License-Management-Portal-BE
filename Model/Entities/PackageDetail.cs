using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

/// <summary>
/// License package details.
/// </summary>
public partial class PackageDetail
{
    /// <summary>
    /// Primary Key
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Encoded flags
    /// </summary>
    public int? Flags { get; set; }

    /// <summary>
    /// Package &quot;PRO-TRNHEV-001&quot;
    /// </summary>
    public string ProductNumber { get; set; } = null!;

    /// <summary>
    /// Product class
    /// </summary>
    public bool? Legacy { get; set; }

    /// <summary>
    /// License file prefix &quot;PRO&quot;,&quot;ENG&quot;
    /// </summary>
    public string Prefix { get; set; } = null!;

    /// <summary>
    /// Package name
    /// &quot;ServiceRanger Professional&quot;
    /// </summary>
    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Product class
    /// </summary>
    public bool? LegacyPlus { get; set; }

    /// <summary>
    /// Product class
    /// </summary>
    public bool? Current { get; set; }

    /// <summary>
    /// Package description
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Last changed date
    /// </summary>
    public DateTime? UpdateDate { get; set; }

    /// <summary>
    /// Base data role key id 5-PRO;222-ENG..
    /// </summary>
    public int RoleKeyId { get; set; }

    /// <summary>
    /// Product class
    /// </summary>
    public bool? Engineering { get; set; }

    /// <summary>
    /// Number of months
    /// </summary>
    public int Subscription { get; set; }

    /// <summary>
    /// Product class
    /// </summary>
    public bool? Advanced { get; set; }

    /// <summary>
    /// Product class
    /// </summary>
    public bool? Hybrid { get; set; }

    public virtual ICollection<OrganizationPackageDetail> OrganizationPackageDetails { get; set; } = new List<OrganizationPackageDetail>();
}

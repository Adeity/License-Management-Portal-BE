using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

/// <summary>
/// License details.
/// </summary>
public partial class SerialNumberDetail
{
    /// <summary>
    /// Account
    /// </summary>
    public string AccountId { get; set; } = null!;

    /// <summary>
    /// Request log
    /// </summary>
    public int SerialNumberRequestLogId { get; set; }

    /// <summary>
    /// Is valid license
    /// </summary>
    public bool IsValid { get; set; }

    /// <summary>
    /// Primary Key
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// License prefix &quot;PRO&quot;,&quot;RFM&quot;
    /// </summary>
    public string Prefix { get; set; } = null!;

    /// <summary>
    /// License expiration date
    /// </summary>
    public DateTime ExpirationDate { get; set; }

    public string ResellerInvoiceLastRenew { get; set; } = null!;

    /// <summary>
    /// Is temporary license
    /// </summary>
    public bool? IsTemp { get; set; }

    public string ResellerInvoice { get; set; } = null!;

    public string ResellerAccount { get; set; } = null!;

    /// <summary>
    /// Product number &quot;PRO-RFM-003&quot;
    /// </summary>
    public string ProductNumber { get; set; } = null!;

    /// <summary>
    /// License number
    /// &quot;RFM-QYF5S0-TVA7K-JG3YA-J32P7-3KNN7-D7KV0&quot;
    /// </summary>
    public string SerialNumber { get; set; } = null!;

    /// <summary>
    /// Last changed date
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Last time license modification where made.
    /// </summary>
    public DateTime? LatestModificationDate { get; set; }

    public string ResellerCode { get; set; } = null!;

    public virtual SerialNumberRequestLog SerialNumberRequestLog { get; set; } = null!;
}

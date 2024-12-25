using System;
using System.Collections.Generic;

namespace DP_BE_LicensePortal.Model.Entities;

/// <summary>
/// License generation request log.
/// </summary>
public partial class SerialNumberRequestLog
{
    /// <summary>
    /// Last changed date
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Request date
    /// </summary>
    public DateTime OrderdDate { get; set; }

    /// <summary>
    /// How many serial numbers got requested (1)
    /// </summary>
    public int RequestedSn { get; set; }

    /// <summary>
    /// Primary Key
    /// </summary>
    public int Id { get; set; }

    public virtual ICollection<SerialNumberDetail> SerialNumberDetails { get; set; } = new List<SerialNumberDetail>();
}

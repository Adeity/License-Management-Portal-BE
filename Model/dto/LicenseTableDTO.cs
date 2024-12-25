using DP_BE_LicensePortal.Entities;

namespace DP_BE_LicensePortal.Model.dto;

public class LicenseTableDTO
{
    /// <summary>
    /// Primary Key from the SerialNumberDetails Table
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// Number of Emails Sent
    /// </summary>
    public int EmailCount { get; set; }
    /// <summary>
    /// Expiration Date Coming from the SerialNumberDetails Table
    /// </summary>
    public DateTime Expires { get; set; }
    /// <summary>
    /// Organization to which the Serial Number Belongs from the
    /// SerialNumberDetails.SubscriptionItems Table
    /// </summary>
    public string Organization { get; set; }
    /// <summary>
    /// ProductNumber from the SerialNumberDetails Table
    /// </summary>
    public string Product_Number { get; set; }
    /// <summary>
    /// Actual Serial Number from the SerialNumberDetails Table
    /// </summary>
    public string Serial_Number { get; set; }
    /// <summary>
    /// Status based on combination of factors from the SerialNumberDetails
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// Verification if there are still transfers left
    /// </summary>
    public bool TransferAllowed { get; set; }
    /// <summary>
    /// Transfer Limit from the config file
    /// </summary>
    public int TransferLimit { get; set; }
    /// <summary>
    /// Number of Transfers Done
    /// </summary>
    public int TransfersDone { get; set; }
}


using System.Runtime.Serialization;

namespace DP_BE_LicensePortal.Services.ResellerAdminService;

[DataContract]
public class RenewResult
{
    [DataMember]
    public bool IsRenewed { get; set; }
    [DataMember]
    public string SerialNumber { get; set; }
    [DataMember]
    public DateTime ExpirationDate { get; set; }
    [DataMember]
    public List<string> ErrorMessage { get; set; }
}
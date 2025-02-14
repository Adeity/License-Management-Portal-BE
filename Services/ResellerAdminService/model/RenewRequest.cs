using System.Runtime.Serialization;

namespace DP_BE_LicensePortal.Services.ResellerAdminService;
public class RenewRequest
{
    [DataMember]
    public string SerialNumber { get; set; }
    
    [DataMember]
    public DateTime ExpirationDate { get; set; }
}

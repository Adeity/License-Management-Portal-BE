using System.Runtime.Serialization;

namespace LicenseManagementPortal.Services.ResellerAdminService;
public class RenewRequest
{
    [DataMember]
    public string SerialNumber { get; set; }

    [DataMember]
    public DateTime ExpirationDate { get; set; }
}

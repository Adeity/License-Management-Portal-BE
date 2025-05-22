using System.Runtime.Serialization;

namespace LicenseManagementPortal.Services.ResellerAdminService;

public class StatusChangeResult
{
    [DataMember]
    public bool IsStatusChanged { get; set; }
    [DataMember]
    public List<string> ErrorMessage { get; set; }
}
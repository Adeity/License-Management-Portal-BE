namespace LicenseManagementPortal.Model.dto.input;

public class SerialNumberRequestLogInputDto
{
    public DateTime UpdateDate { get; set; }
    public DateTime OrderdDate { get; set; }
    public int RequestedSn { get; set; }
}
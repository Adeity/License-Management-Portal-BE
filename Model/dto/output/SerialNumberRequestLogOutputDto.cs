namespace LicenseManagementPortal.Model.dto.input;

public class SerialNumberRequestLogOutputDto
{
    public DateTime UpdateDate { get; set; }
    public DateTime OrderdDate { get; set; }
    public int RequestedSn { get; set; }
    public int Id { get; set; }
    public List<SerialNumberDetailOutputDto> SerialNumberDetails { get; set; } = new List<SerialNumberDetailOutputDto>();
}
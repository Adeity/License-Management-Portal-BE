namespace LicenseManagementPortal.Model.dto;
public class ErrorResponseDto
{
    public string Message { get; set; }
    public string? Code { get; set; } // optional internal code
    public Dictionary<string, string>? Details { get; set; } // optional details
}


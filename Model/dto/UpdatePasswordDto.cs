namespace DP_BE_LicensePortal.Model.dto;

public class UpdatePasswordDto
{
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}
namespace LicenseManagementPortal.Model.dto.input;

public class UserInputDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; } = null!;
    public int? IsSmart { get; set; }
    public string? WindowsUserName { get; set; }
}
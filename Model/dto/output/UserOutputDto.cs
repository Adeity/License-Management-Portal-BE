namespace LicenseManagementPortal.Model.dto.input;

public class UserOutputDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int? IsSmart { get; set; }
    public List<OrganizationContactOutputDto> OrganizationContacts { get; set; } = new List<OrganizationContactOutputDto>();
}
namespace DP_BE_LicensePortal.Model.dto.input;

public class OrganizationRoleOutputDto
{
    public string Name { get; set; } = null!;
    public DateTime UpdateDate { get; set; }
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public List<OrganizationContactOutputDto> OrganizationContacts { get; set; } = new List<OrganizationContactOutputDto>();
}
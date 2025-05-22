namespace LicenseManagementPortal.Model.dto.input;

public class OrganizationAccountInputDto
{
    public string Name { get; set; } = null!;
    public int? ParentOrganizationId { get; set; }
    public string? AccountId { get; set; }
    public int OrganizationTypeId { get; set; }
    public bool? IsDeleted { get; set; } = false;
}
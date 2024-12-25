namespace DP_BE_LicensePortal.Model.dto.input;

public class OrganizationAccountInputDto
{
    public string Name { get; set; } = null!;
    public int? ParentOrganizationId { get; set; }
    public string UserId { get; set; } = null!;
    public string? AccountId { get; set; }
    public int OrganizationTypeId { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsDeleted { get; set; }
}
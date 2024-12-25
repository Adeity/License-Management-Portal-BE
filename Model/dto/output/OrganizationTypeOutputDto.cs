namespace DP_BE_LicensePortal.Model.dto.input;

public class OrganizationTypeOutputDto
{
    public DateTime UpdateDate { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = null!;
    public List<OrganizationAccountOutputDto> OrganizationAccounts { get; set; } = new List<OrganizationAccountOutputDto>();
}
using DP_BE_LicensePortal.Model.dto.output;

namespace DP_BE_LicensePortal.Model.dto.input;

public class OrganizationContactOutputDto
{
    public int OrganizationRoleId { get; set; }
    public int? UserId { get; set; }
    public DateTime UpdateDate { get; set; }
    public int Id { get; set; }
    public int OrganizationAccountId { get; set; }
    public int ContactTypeId { get; set; }
    public ContactTypeOutputDto ContactType { get; set; } = null!;
    public OrganizationAccountOutputDto OrganizationAccount { get; set; } = null!;
    public OrganizationRoleOutputDto OrganizationRole { get; set; } = null!;
    public UserOutputDto? User { get; set; }
}
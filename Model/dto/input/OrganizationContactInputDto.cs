namespace LicenseManagementPortal.Model.dto.input;

public class OrganizationContactInputDto
{
    public int OrganizationRoleId { get; set; }
    public string UserID { get; set; }
    public DateTime UpdateDate { get; set; }
    public int OrganizationAccountId { get; set; }
    public int ContactTypeId { get; set; }
}
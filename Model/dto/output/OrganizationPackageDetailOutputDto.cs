namespace LicenseManagementPortal.Model.dto.input;

public class OrganizationPackageDetailOutputDto
{
    public int Id { get; set; }
    public int SerialNumbersCount { get; set; }
    public DateTime UpdateDate { get; set; }
    public int PackageDetailsId { get; set; }
    public int OrganizationAccountId { get; set; }
    public string PackageDetailTitle { get; set; }
    public int PackageDetailId { get; set; }
    public OrganizationAccountOutputDto OrganizationAccount { get; set; } = null!;
    public PackageDetailOutputDto PackageDetails { get; set; } = null!;
}
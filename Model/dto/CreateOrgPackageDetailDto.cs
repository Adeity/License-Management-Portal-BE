namespace LicenseManagementPortal.Model.dto;

public class CreateOrgPackageDetailDto
{
    public required int QuantityOfLicenses { get; set; }
    public required int PackageDetailsId { get; set; }
    public required int OrganizationAccountId { get; set; }
}
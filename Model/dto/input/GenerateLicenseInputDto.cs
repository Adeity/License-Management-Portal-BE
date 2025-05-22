using System.ComponentModel.DataAnnotations;

namespace LicenseManagementPortal.Model.dto.input;

public class GenerateLicenseInputDto
{
    public required int OrganizationAccountId { get; set; }
    public required int PackageDetailsId { get; set; }
    [AllowedValues(1)]
    public int QuantityOfLicenses { get; set; } = 1;
}
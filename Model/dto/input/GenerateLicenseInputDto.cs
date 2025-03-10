using System.ComponentModel.DataAnnotations;

namespace DP_BE_LicensePortal.Model.dto.input;

public class GenerateLicenseInputDto
{
    public int OrganizationAccountId { get; set;  }
    public int PackageDetailsId { get; set; }
    [AllowedValues(1)]
    public int QuantityOfLicenses { get; set; } = 1;
}
namespace DP_BE_LicensePortal.Model.dto.input;

public class GenerateLicenseInputDto
{
    public int OrganizationAccountId { get; set;  }
    public int PackageDetailsId { get; set; }
    public int QuantityOfLicenses { get; set; }
}
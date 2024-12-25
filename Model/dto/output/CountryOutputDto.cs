using DP_BE_LicensePortal.Model.dto.input;

namespace DP_BE_LicensePortal.Model.dto.output;

public class CountryOutputDto
{
    public DateTime UpdateDate { get; set; }
    public int Id { get; set; }
    public int SelectOrder { get; set; }
    public string Name { get; set; } = null!;
    public List<OrganizationAddressOutputDto> OrganizationAddresses { get; set; } = new List<OrganizationAddressOutputDto>();
}
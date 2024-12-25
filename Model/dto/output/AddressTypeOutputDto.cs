using DP_BE_LicensePortal.Model.dto.input;

namespace DP_BE_LicensePortal.Model.dto.output;

public class AddressTypeOutputDto
{
    public string Description { get; set; } = null!;
    public DateTime UpdateDate { get; set; }
    public string Name { get; set; } = null!;
    public int Id { get; set; }
    public List<OrganizationAddressOutputDto> OrganizationAddresses { get; set; } = new List<OrganizationAddressOutputDto>();
}
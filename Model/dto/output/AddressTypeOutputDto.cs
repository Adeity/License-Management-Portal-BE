
using LicenseManagementPortal.Model.dto.input;

namespace LicenseManagementPortal.Model.dto.output;

public class AddressTypeOutputDto
{
    public string Description { get; set; } = null!;
    public DateTime UpdateDate { get; set; }
    public string Name { get; set; } = null!;
    public int Id { get; set; }
    public List<OrganizationAddressOutputDto> OrganizationAddresses { get; set; } = new List<OrganizationAddressOutputDto>();
}
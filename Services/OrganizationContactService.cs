using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Mappers;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;

namespace LicenseManagementPortal.Services;

public class OrganizationContactService : IOrganizationContactService
{

    private readonly IOrganizationContactRepository _organizationContactRepository;


    public OrganizationContactService(
        IOrganizationContactRepository organizationContactRepository
        )
    {
        _organizationContactRepository = organizationContactRepository;
    }


    public async Task<OrganizationContactOutputDto?> GetByAspNetUserId(string aspNetUserId)
    {
        var res = await _organizationContactRepository.GetByAspNetUserId(aspNetUserId);
        return res.ToOutputDto();
    }
}
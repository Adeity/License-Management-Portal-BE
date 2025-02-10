using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;

namespace DP_BE_LicensePortal.Services;

public class ResellerService: IResellerService
{
    private readonly IOrganizationAccountRepository _organizationAccountRepository;
    
    public ResellerService(IOrganizationAccountRepository organizationAccountRepository)
    {
        _organizationAccountRepository = organizationAccountRepository;
    }
    
    public async Task<List<OrganizationAccountOutputDto>> GetAllResellers()
    {
        var result = await _organizationAccountRepository.GetAllWithoutParentIdAsync();
        var dtoList = result.Select(entity => entity.ToOutputDto()).ToList();

        return dtoList;
    }
}
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Services;

public class OrganizationAccountService : IOrganizationAccountService
{
    private readonly IOrganizationAccountRepository _organizationAccountRepository;

    public OrganizationAccountService(IOrganizationAccountRepository organizationAccountRepository)
    {
        _organizationAccountRepository = organizationAccountRepository;
    }

    public async Task<OrganizationAccountOutputDto> GetByIdAsync(int id)
    {
        return await _organizationAccountRepository.GetByIdAsync(id);
    }

    public async Task<Pagination<OrganizationAccountOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        return await _organizationAccountRepository.GetAllAsync(pageIndex, pageSize);
    }

    public async Task<OrganizationAccountOutputDto> AddAsync(OrganizationAccountInputDto dto)
    {
        return await _organizationAccountRepository.AddAsync(dto);
    }

    public async Task<OrganizationAccountOutputDto> UpdateAsync(int id, OrganizationAccountInputDto dto)
    {
        return await _organizationAccountRepository.UpdateAsync(id, dto);
    }

    public async Task DeleteAsync(int id)
    {
        await _organizationAccountRepository.DeleteAsync(id);
    }
}
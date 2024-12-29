using DP_BE_LicensePortal.Entities;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Repositories.Interfaces;

public interface IOrganizationAccountRepository
{
    Task<OrganizationAccountOutputDto> GetByIdAsync(int id);
    Task<Pagination<OrganizationAccountOutputDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<OrganizationAccountOutputDto> AddAsync(OrganizationAccountInputDto dto);
    Task<OrganizationAccountOutputDto> UpdateAsync(int id, OrganizationAccountInputDto dto);
    Task DeleteAsync(int id);
}
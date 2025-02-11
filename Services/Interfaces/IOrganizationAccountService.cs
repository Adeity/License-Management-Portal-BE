using DP_BE_LicensePortal.Model.dto;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Services.Interfaces;

public interface IOrganizationAccountService
{
    Task<OrganizationAccountOutputDto?> GetByIdAsync(int id);
    Task<List<LicenseTableDTO>> GetLicensesByOrganizationIdAsync(int id);
    Task<Pagination<OrganizationAccountOutputDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<OrganizationAccountOutputDto> AddAsync(OrganizationAccountInputDto dto);
    Task<OrganizationAccountOutputDto> UpdateAsync(int id, OrganizationAccountInputDto dto);
    Task DeleteAsync(int id);
    Task<List<OrganizationAccountOutputDto>> GetAllByResellerIdAsync(int resellerId);
}
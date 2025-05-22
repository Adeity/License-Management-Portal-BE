using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Services.Interfaces;

public interface IOrganizationAccountService
{
    Task<OrganizationAccountOutputDto?> GetByIdAsync(int id);
    Task<Pagination<OrganizationAccountOutputDto>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<OrganizationAccountOutputDto> AddAsync(OrganizationAccountInputDto dto);
    Task<OrganizationAccountOutputDto> UpdateAsync(int id, OrganizationAccountInputDto dto);
    Task DeleteAsync(int id);
    Task DeleteOrgPackageDetailAsync(int id, int organizationPackageDetailId);
    Task UpdateOrgPackageDetailCountAsync(int id, int organizationPackageDetailId, int newCount);
    Task<bool> IsChildOrganizationOfReseller(int organizationId, int resellerId);
}
using LicenseManagementPortal.Model.dto.input;

namespace LicenseManagementPortal.Services.Interfaces;

public interface IOrganizationPackageDetailsService
{
    Task<OrganizationPackageDetailOutputDto> AddAsync(OrganizationPackageDetailInputDto dto);
    Task<OrganizationPackageDetailOutputDto?> GetByOrganizationIdAndPackageDetailsId(int organizationAccountId, int packageDetailsId);
    Task<OrganizationPackageDetailOutputDto> UpdateAsync(int id, OrganizationPackageDetailInputDto dto);
    Task<OrganizationPackageDetailOutputDto> UpdateSerialNumbersCountAsync(int id, int newCount);
    Task<OrganizationPackageDetailOutputDto> CreateAsync(int organizationAccountId, int packageDetailsId, int quantityOfLicenses);
    Task DeleteAsync(int id);
    Task<bool> BelongsToOrganizationAccountAsync(int detailId, int organizationAccountId);
}
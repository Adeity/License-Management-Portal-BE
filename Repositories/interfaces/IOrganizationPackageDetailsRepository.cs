using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Repositories.Interfaces;

public interface IOrganizationPackageDetailsRepository
{
    Task<IEnumerable<OrganizationPackageDetail>> GetByOrganizationAccountId(int organizationAccountId);
    Task<OrganizationPackageDetail?> GetByOrganizationIdAndPackageDetailsId(int organizationAccountId, int packageDetailsId);
    Task<OrganizationPackageDetail?> GetByIdAsync(int id);
    Task<OrganizationPackageDetail> AddAsync(OrganizationPackageDetail entity);
    Task<OrganizationPackageDetail> UpdateAsync(OrganizationPackageDetail entity);
    Task DeleteAsync(OrganizationPackageDetail entity);
    Task<bool> BelongsToOrganizationAccountAsync(int detailId, int organizationAccountId);
}
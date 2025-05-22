using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Repositories.Interfaces
{
    public interface IOrganizationAccountRepository
    {
        Task<OrganizationAccount?> GetByIdAsync(int id);
        Task<Pagination<OrganizationAccount>> GetAllPaginatedAsync(int pageIndex, int pageSize);
        Task<IEnumerable<OrganizationAccount>> GetAllAsync();
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> IsChildOrganizationOfReseller(int organizationId, int resellerId);
        Task<string?> GetNameByIdAsync(int id);
        Task<List<OrganizationAccount>> GetAllWithoutParentIdAsync(); // Retrieves resellers
        Task<OrganizationAccount> AddAsync(OrganizationAccount entity);
        Task<OrganizationAccount> UpdateAsync(int id, OrganizationAccount entity);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<Pagination<OrganizationAccount>> GetAllByResellerIdPaginatedAsync(int resellerId, int pageIndex, int pageSize);
        Task<IEnumerable<OrganizationAccount>> GetAllByResellerIdAsync(int resellerId);
    }
}
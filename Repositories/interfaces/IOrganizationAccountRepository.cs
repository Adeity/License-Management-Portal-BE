using System.Collections.Generic;
using System.Threading.Tasks;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Repositories.Interfaces
{
    public interface IOrganizationAccountRepository
    {
        Task<OrganizationAccount?> GetByIdAsync(int id);
        Task<Pagination<OrganizationAccount>> GetAllAsync(int pageIndex, int pageSize);
        Task<bool> ExistsByIdAsync(int id);
        Task<List<OrganizationAccount>> GetAllWithoutParentIdAsync(); // Retrieves resellers
        Task<OrganizationAccount> AddAsync(OrganizationAccount entity);
        Task<OrganizationAccount> UpdateAsync(int id, OrganizationAccount entity);
        Task DeleteAsync(int id);
        Task<List<OrganizationAccount>> GetAllByResellerIdAsync(int resellerId); 
    }
}
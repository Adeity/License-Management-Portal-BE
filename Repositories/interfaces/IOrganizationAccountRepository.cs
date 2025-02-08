using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Utilities;
using System.Threading.Tasks;

namespace DP_BE_LicensePortal.Repositories.Interfaces
{
    public interface IOrganizationAccountRepository
    {
        Task<OrganizationAccount> GetByIdAsync(int id);
        Task<Pagination<OrganizationAccount>> GetAllAsync(int pageIndex, int pageSize);
        Task<OrganizationAccount> AddAsync(OrganizationAccount entity);
        Task<OrganizationAccount> UpdateAsync(int id, OrganizationAccount entity);
        Task DeleteAsync(int id);
    }
}
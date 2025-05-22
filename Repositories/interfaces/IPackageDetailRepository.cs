using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Utilities;
using System.Threading.Tasks;

namespace LicenseManagementPortal.Repositories.Interfaces
{
    public interface IPackageDetailRepository
    {
        Task<PackageDetail?> GetByIdAsync(int id);
        Task<Pagination<PackageDetail>> GetAllPaginatedAsync(int pageIndex, int pageSize);
        Task<IEnumerable<PackageDetail>> GetAllAsync();
        Task<PackageDetail> AddAsync(PackageDetail entity);
        Task<PackageDetail> UpdateAsync(int id, PackageDetail entity);
        Task DeleteAsync(int id);
    }
}
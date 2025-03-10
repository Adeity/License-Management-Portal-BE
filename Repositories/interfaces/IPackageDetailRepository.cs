using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Utilities;
using System.Threading.Tasks;

namespace DP_BE_LicensePortal.Repositories.Interfaces
{
    public interface IPackageDetailRepository
    {
        Task<PackageDetail?> GetByIdAsync(int id);
        Task<Pagination<PackageDetail>> GetAllAsync(int pageIndex, int pageSize);
        Task<PackageDetail> AddAsync(PackageDetail entity);
        Task<PackageDetail> UpdateAsync(int id, PackageDetail entity);
        Task DeleteAsync(int id);
    }
}
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Utilities;
using System.Threading.Tasks;

namespace DP_BE_LicensePortal.Repositories.Interfaces
{
    public interface ISerialNumberDetailRepository
    {
        Task<SerialNumberDetail?> GetByIdAsync(int id);
        Task<Pagination<SerialNumberDetail>> GetAllAsync(int pageIndex, int pageSize);
        Task<SerialNumberDetail> AddAsync(SerialNumberDetail entity);
        Task<SerialNumberDetail> UpdateAsync(int id, SerialNumberDetail entity);
        Task DeleteAsync(int id);
    }
}
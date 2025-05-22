using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Utilities;
using System.Threading.Tasks;

namespace LicenseManagementPortal.Repositories.Interfaces
{
    public interface ISerialNumberDetailRepository
    {
        Task<SerialNumberDetail?> GetByIdAsync(int id);
        Task<Pagination<SerialNumberDetail>> GetAllAsync(int pageIndex, int pageSize);
        Task<int> GetIdBySerialNumber(string serialNumber);
        Task<List<int>> GetIdsByOrganizationIdAsync(int organizationId);
        Task<Pagination<SerialNumberDetail>> GetByIdsAndOrganizationId(int organizationId, List<int> ids, int pageIndex, int pageSize);
        Task<SerialNumberDetail> AddAsync(SerialNumberDetail entity);
        Task<SerialNumberDetail> UpdateAsync(int id, SerialNumberDetail entity);
        Task DeleteAsync(int id);
        Task<bool> OrganizationHasSerialNumberDetailAsync(int organizationId, int serialNumberDetailId);
    }
}
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Repositories.Interfaces;

public interface ISerialNumberRequestLogRepository
{
    Task<SerialNumberRequestLog> AddAsync(SerialNumberRequestLog entity);
}
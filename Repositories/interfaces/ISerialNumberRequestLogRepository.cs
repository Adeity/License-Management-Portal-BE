using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Repositories.Interfaces;

public interface ISerialNumberRequestLogRepository
{
    Task<SerialNumberRequestLog> AddAsync(SerialNumberRequestLog entity);
}
using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories.Interfaces;

namespace LicenseManagementPortal.Repositories;

public class SerialNumberRequestLogRepository : ISerialNumberRequestLogRepository
{
    private readonly MyDbContext _context;
    public SerialNumberRequestLogRepository(MyDbContext context)
    {
        _context = context;
    }
    public async Task<SerialNumberRequestLog> AddAsync(SerialNumberRequestLog entity)
    {
        _context.Set<SerialNumberRequestLog>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
using DP_BE_LicensePortal.Context;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Repositories;

public class SerialNumberRequestLogRepository
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
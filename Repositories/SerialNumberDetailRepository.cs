using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Repositories;
public class SerialNumberDetailRepository : ISerialNumberDetailRepository
{
    private readonly DbContext _context;

    public SerialNumberDetailRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<SerialNumberDetailOutputDto> GetByIdAsync(int id)
    {
        var entity = await _context.Set<SerialNumberDetail>().FindAsync(id);
        return entity?.ToOutputDto();
    }

    public async Task<Pagination<SerialNumberDetailOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        var list = await _context.Set<SerialNumberDetail>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalItems = await _context.Set<SerialNumberDetail>().CountAsync();
        var dtoList = list.Select(snd => snd.ToOutputDto()).ToList();

        return new Pagination<SerialNumberDetailOutputDto>(dtoList, totalItems, pageIndex, pageSize);
    }

    public async Task<SerialNumberDetailOutputDto> AddAsync(SerialNumberDetailInputDto dto)
    {
        var entity = dto.ToEntity();
        _context.Set<SerialNumberDetail>().Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task<SerialNumberDetailOutputDto> UpdateAsync(int id, SerialNumberDetailInputDto dto)
    {
        var entity = await _context.Set<SerialNumberDetail>().FindAsync(id);
        if (entity == null) return null;

        entity.AccountId = dto.AccountId;
        entity.SerialNumberRequestLogId = dto.SerialNumberRequestLogId;
        entity.IsValid = dto.IsValid;
        entity.Prefix = dto.Prefix;
        entity.ExpirationDate = dto.ExpirationDate;
        entity.ResellerInvoiceLastRenew = dto.ResellerInvoiceLastRenew;
        entity.IsTemp = dto.IsTemp;
        entity.ResellerInvoice = dto.ResellerInvoice;
        entity.ResellerAccount = dto.ResellerAccount;
        entity.ProductNumber = dto.ProductNumber;
        entity.SerialNumber = dto.SerialNumber;
        entity.UpdateDate = dto.UpdateDate;
        entity.LatestModificationDate = dto.LatestModificationDate;
        entity.ResellerCode = dto.ResellerCode;

        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<SerialNumberDetail>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<SerialNumberDetail>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

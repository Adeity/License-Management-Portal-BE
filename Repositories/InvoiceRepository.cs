using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly DbContext _context;

    public InvoiceRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<InvoiceOutputDto> GetByIdAsync(int id)
    {
        var entity = await _context.Set<Invoice>().FindAsync(id);
        return entity?.ToOutputDto();
    }

    public async Task<Pagination<InvoiceOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        var list = await _context.Set<Invoice>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalItems = await _context.Set<Invoice>().CountAsync();
        var dtoList = list.Select(i => i.ToOutputDto()).ToList();

        return new Pagination<InvoiceOutputDto>(dtoList, totalItems, pageIndex, pageSize);
    }

    public async Task<InvoiceOutputDto> AddAsync(InvoiceInputDto dto)
    {
        var entity = dto.ToEntity();
        _context.Set<Invoice>().Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task<InvoiceOutputDto> UpdateAsync(int id, InvoiceInputDto dto)
    {
        var entity = await _context.Set<Invoice>().FindAsync(id);
        if (entity == null) return null;

        entity.InvoiceTypeId = dto.InvoiceTypeId;
        entity.OrganizationAccountId = dto.OrganizationAccountId;
        entity.UpdateDate = dto.UpdateDate;

        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<Invoice>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<Invoice>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Utilities;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly MyDbContext _context;

    public InvoiceRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Invoice?> GetByIdAsync(int id)
    {
        var entity = await _context.Set<Invoice>().FindAsync(id);
        return entity;
    }

    public async Task<Pagination<Invoice>> GetAllAsync(int pageIndex, int pageSize)
    {
        var list = await _context.Set<Invoice>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalItems = await _context.Set<Invoice>().CountAsync();

        return new Pagination<Invoice>(list, totalItems, pageIndex, pageSize);
    }

    public async Task<Invoice> AddAsync(Invoice entity)
    {
        _context.Set<Invoice>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Invoice> UpdateAsync(int id, Invoice entity)
    {
        _context.Set<Invoice>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;

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
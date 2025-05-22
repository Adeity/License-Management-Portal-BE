using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Repositories;

public class OrganizationPackageDetailsRepository : IOrganizationPackageDetailsRepository
{
    private readonly MyDbContext _context;
    public OrganizationPackageDetailsRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrganizationPackageDetail>> GetByOrganizationAccountId(int organizationAccountId)
    {
        return await _context.Set<OrganizationPackageDetail>()
            .Include("PackageDetails")
            .Where(e => e.OrganizationAccountId == organizationAccountId)
            .ToListAsync();
    }

    public async Task<OrganizationPackageDetail?> GetByOrganizationIdAndPackageDetailsId(int organizationAccountId, int packageDetailsId)
    {
        return await _context.Set<OrganizationPackageDetail>()
            .Where(e => e.OrganizationAccountId == organizationAccountId && e.PackageDetailsId == packageDetailsId)
            .FirstOrDefaultAsync();
    }

    public async Task<OrganizationPackageDetail?> GetByIdAsync(int id)
    {
        return await _context.Set<OrganizationPackageDetail>()
            .Include(x => x.PackageDetails)
            .Include(x => x.OrganizationAccount)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<OrganizationPackageDetail> AddAsync(OrganizationPackageDetail entity)
    {
        _context.Set<OrganizationPackageDetail>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<OrganizationPackageDetail> UpdateAsync(OrganizationPackageDetail entity)
    {
        _context.Set<OrganizationPackageDetail>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(OrganizationPackageDetail entity)
    {
        _context.Set<OrganizationPackageDetail>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> BelongsToOrganizationAccountAsync(int detailId, int organizationAccountId)
    {
        return await _context.Set<OrganizationPackageDetail>()
            .AnyAsync(d => d.Id == detailId && d.OrganizationAccountId == organizationAccountId);
    }


}
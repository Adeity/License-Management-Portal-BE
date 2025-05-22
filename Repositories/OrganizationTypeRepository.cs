using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Model.Mappers;
using LicenseManagementPortal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Repositories;

public class OrganizationTypeRepository : IOrganizationTypeRepository
{
    private readonly MyDbContext _context;

    public OrganizationTypeRepository(MyDbContext context)
    {
        _context = context;
    }
    public async Task<OrganizationType?> GetByIdAsync(int id)
    {
        var res = await _context.OrganizationTypes
            .Include("OrganizationAccounts")
            .Where(e => e.Id == id).FirstOrDefaultAsync();
        return res;
    }

    public async Task<List<OrganizationType>> GetAll()
    {
        var organizationsTypes = await _context.Set<OrganizationType>()
            .ToListAsync();
        return organizationsTypes;
    }
}
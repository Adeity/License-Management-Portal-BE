using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Repositories;

public class OrganizationContactRepository : IOrganizationContactRepository
{
    private readonly MyDbContext _context;

    public OrganizationContactRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<OrganizationContact?> GetByAspNetUserId(string userId)
    {
        return await _context.Set<OrganizationContact>()
            .Include("LoginUser")
            .FirstOrDefaultAsync(o => o.LoginUser.Id == userId);
    }
}
using DP_BE_LicensePortal.Context;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace DP_BE_LicensePortal.Repositories
{
    public class OrganizationAccountRepository : IOrganizationAccountRepository
    {
        private readonly MyDbContext _context;

        public OrganizationAccountRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<OrganizationAccount> GetByIdAsync(int id)
        {
            return await _context.Set<OrganizationAccount>().FindAsync(id);
        }

        public async Task<Pagination<OrganizationAccount>> GetAllAsync(int pageIndex, int pageSize)
        {
            var list = await _context.Set<OrganizationAccount>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = await _context.Set<OrganizationAccount>().CountAsync();

            return new Pagination<OrganizationAccount>(list, totalItems, pageIndex, pageSize);
        }

        public async Task<OrganizationAccount> AddAsync(OrganizationAccount entity)
        {
            _context.Set<OrganizationAccount>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<OrganizationAccount> UpdateAsync(int id, OrganizationAccount entity)
        {
            _context.Set<OrganizationAccount>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<OrganizationAccount>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<OrganizationAccount>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

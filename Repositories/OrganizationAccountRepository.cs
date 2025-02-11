using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DP_BE_LicensePortal.Context;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Repositories
{
    public class OrganizationAccountRepository : IOrganizationAccountRepository
    {
        private readonly MyDbContext _context;

        public OrganizationAccountRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<OrganizationAccount?> GetByIdAsync(int id)
        {
            return await _context.Set<OrganizationAccount>().FindAsync(id);
        }

        public async Task<Pagination<OrganizationAccount>> GetAllAsync(int pageIndex, int pageSize)
        {
            var query = _context.Set<OrganizationAccount>();

            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Pagination<OrganizationAccount>(items, totalItems, pageIndex, pageSize);
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            return _context.Set<OrganizationAccount>().AnyAsync(e => e.Id == id);
        }

        public Task<string?> GetNameByIdAsync(int id)
        {
            return _context.Set<OrganizationAccount>()
                .Where(e => e.Id == id)
                .Select(e => e.Name)
                .FirstOrDefaultAsync();
        }

        // This retrieves all resellers;
        public async Task<List<OrganizationAccount>> GetAllWithoutParentIdAsync()
        {
            var query = _context.Set<OrganizationAccount>();

            var items = await query
                .Where(e => e.ParentOrganizationId == null)
                .ToListAsync();

            return items;
        }

        public async Task<OrganizationAccount> AddAsync(OrganizationAccount entity)
        {
            _context.Set<OrganizationAccount>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<OrganizationAccount> UpdateAsync(int id, OrganizationAccount entity)
        {
            var existingEntity = await _context.Set<OrganizationAccount>().FindAsync(id);
            if (existingEntity == null) return null;

            existingEntity.Name = entity.Name;
            existingEntity.ParentOrganizationId = entity.ParentOrganizationId;
            existingEntity.UserID = entity.UserID;
            existingEntity.AccountID = entity.AccountID;
            existingEntity.OrganizationTypeId = entity.OrganizationTypeId;
            existingEntity.UpdateDate = entity.UpdateDate;
            existingEntity.IsDeleted = entity.IsDeleted;

            await _context.SaveChangesAsync();
            return existingEntity;
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

        public async Task<List<OrganizationAccount>> GetAllByResellerIdAsync(int resellerId)
        {
            return await _context.Set<OrganizationAccount>()
                .Where(o => o.ParentOrganizationId == resellerId)
                .ToListAsync();
        }
    }
}

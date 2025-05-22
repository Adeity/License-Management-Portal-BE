using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Utilities;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Repositories
{
    public class OrganizationAccountRepository : IOrganizationAccountRepository
    {
        private readonly MyDbContext _context;
        private readonly IDbContextFactory<MyDbContext> _contextFactory;

        public OrganizationAccountRepository(MyDbContext context, IDbContextFactory<MyDbContext> contextFactory)
        {
            _context = context;
            _contextFactory = contextFactory;
        }

        public async Task<OrganizationAccount?> GetByIdAsync(int id)
        {
            return await _context.Set<OrganizationAccount>()
                .Include("OrganizationType")
                .Include("ParentOrganization")
                .Include("OrganizationPackageDetails")
                .Include("OrganizationPackageDetails.PackageDetails")
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Pagination<OrganizationAccount>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var query = _context.Set<OrganizationAccount>();

            var totalItems = await query.CountAsync();
            var items = await query
                .Include("OrganizationType")
                .Include("ParentOrganization")
                .OrderByDescending(e=>e.UpdateDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Pagination<OrganizationAccount>(items, totalItems, pageIndex, pageSize);
        }

        public async Task<IEnumerable<OrganizationAccount>> GetAllAsync()
        {
            var query = _context.Set<OrganizationAccount>();

            var items = await query
                .Include("OrganizationType")
                .Include("ParentOrganization")
                .OrderByDescending(e=>e.UpdateDate)
                .ToListAsync();

            return items;
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            return _context.Set<OrganizationAccount>().AnyAsync(e => e.Id == id);
        }

        public Task<bool> IsChildOrganizationOfReseller(int organizationId, int resellerId)
        {
            return _context.Set<OrganizationAccount>()
                .AnyAsync(e => e.Id == organizationId && e.ParentOrganizationId == resellerId);
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
                .OrderByDescending(e=>e.UpdateDate)
                .ToListAsync();

            return items;
        }

        public async Task<OrganizationAccount> AddAsync(OrganizationAccount entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                entity.OrganizationType = await context.OrganizationTypes.FindAsync(entity.OrganizationTypeId);
                context.Set<OrganizationAccount>().Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
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
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = await _context.Set<OrganizationAccount>().FindAsync(id);
                if (entity != null)
                {
                    entity.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RestoreAsync(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = await _context.Set<OrganizationAccount>().FindAsync(id);
                if (entity != null)
                {
                    entity.IsDeleted = false;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<Pagination<OrganizationAccount>> GetAllByResellerIdPaginatedAsync(int resellerId, int pageIndex, int pageSize)
        {
            var entities = await _context.Set<OrganizationAccount>()
                .Where(o => o.ParentOrganizationId == resellerId)
                .Include("OrganizationType")
                .Include("ParentOrganization")
                .OrderByDescending(e=>e.UpdateDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = await _context.Set<OrganizationAccount>()
                .Where(o => o.ParentOrganizationId == resellerId).CountAsync();

            return new Pagination<OrganizationAccount>(entities, totalItems, pageIndex, pageSize);
        }

        public async Task<IEnumerable<OrganizationAccount>> GetAllByResellerIdAsync(int resellerId)
        {
            var entities = await _context.Set<OrganizationAccount>()
                .Where(o => o.ParentOrganizationId == resellerId)
                .Include("OrganizationType")
                .Include("ParentOrganization")
                .OrderByDescending(e=>e.UpdateDate)
                .ToListAsync();

            return entities;
        }
    }
}

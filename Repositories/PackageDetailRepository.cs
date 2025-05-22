using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace LicenseManagementPortal.Repositories
{
    public class PackageDetailRepository : IPackageDetailRepository
    {
        private readonly MyDbContext _context;

        public PackageDetailRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<PackageDetail?> GetByIdAsync(int id)
        {
            return await _context.Set<PackageDetail>().FindAsync(id);
        }

        public async Task<Pagination<PackageDetail>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var list = await _context.Set<PackageDetail>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = await _context.Set<PackageDetail>().CountAsync();

            return new Pagination<PackageDetail>(list, totalItems, pageIndex, pageSize);
        }

        public async Task<IEnumerable<PackageDetail>> GetAllAsync()
        {
            var list = await _context.Set<PackageDetail>()
                .ToListAsync();

            return list;
        }

        public async Task<PackageDetail> AddAsync(PackageDetail entity)
        {
            _context.Set<PackageDetail>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PackageDetail> UpdateAsync(int id, PackageDetail entity)
        {
            _context.Set<PackageDetail>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<PackageDetail>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<PackageDetail>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

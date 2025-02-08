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
    public class SerialNumberDetailRepository : ISerialNumberDetailRepository
    {
        private readonly MyDbContext _context;

        public SerialNumberDetailRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<SerialNumberDetail> GetByIdAsync(int id)
        {
            return await _context.Set<SerialNumberDetail>().FindAsync(id);
        }

        public async Task<Pagination<SerialNumberDetail>> GetAllAsync(int pageIndex, int pageSize)
        {
            var list = await _context.Set<SerialNumberDetail>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = await _context.Set<SerialNumberDetail>().CountAsync();

            return new Pagination<SerialNumberDetail>(list, totalItems, pageIndex, pageSize);
        }

        public async Task<SerialNumberDetail> AddAsync(SerialNumberDetail entity)
        {
            _context.Set<SerialNumberDetail>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SerialNumberDetail> UpdateAsync(int id, SerialNumberDetail entity)
        {
            _context.Set<SerialNumberDetail>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
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
}

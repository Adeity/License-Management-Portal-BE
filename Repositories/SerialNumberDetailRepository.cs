using DP_BE_LicensePortal.Context;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DP_BE_LicensePortal.Model.dto;
using DP_BE_LicensePortal.Model.Enums;

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

        public async Task<List<int>> GetIdsByOrganizationIdAsync(int organizationId)
        {
            return await _context.Set<SubscriptionItem>()
                .Where(sItem =>
                    (sItem.Invoice.InvoiceTypeId == (int)InvoiceTypeEnum.Create_New_Licenses ||
                     sItem.Invoice.InvoiceTypeId == (int)InvoiceTypeEnum.Move_License) &&
                    sItem.Invoice.OrganizationAccount.Id == organizationId)
                .Select(sItem => sItem.SerialNumberDetailsId)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<SerialNumberDetail>> GetByIdsAndOrganizationId(int organizationId, List<int> ids)
        {
            var sDetailsByOrgId = await _context.SerialNumberDetails
                .Include(s => s.SubscriptionItems)
                .ThenInclude(si => si.Invoice)
                .ThenInclude(i => i.InvoiceType)
                .Include(s => s.SubscriptionItems)
                .ThenInclude(si => si.Invoice)
                .ThenInclude(i => i.OrganizationAccount)
                .Include(s => s.ActivationDetails)
                .Include(s => s.ActivationStatusLogs)
                .Include(s => s.SerialNumberRequestLog)
                .Where(sDetails => ids.Contains(sDetails.ID))
                .ToListAsync();

            // It is necessary to filter the SNDetails for which the LATEST relevant Subscription Item is from the requested
            // Organization Id
            return sDetailsByOrgId
                .Where(snDetails => snDetails.SubscriptionItems
                    .OrderBy(sItem => sItem.UpdateDate)
                    .Last().Invoice.OrganizationAccount.Id == organizationId)
                .ToList();
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

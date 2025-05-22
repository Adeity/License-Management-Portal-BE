using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Model.Enums;
using InvoiceType = LicenseManagementPortal.Model.Enums.InvoiceType;

namespace LicenseManagementPortal.Repositories
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
                .OrderByDescending(e=>e.UpdateDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = await _context.Set<SerialNumberDetail>().CountAsync();

            return new Pagination<SerialNumberDetail>(list, totalItems, pageIndex, pageSize);
        }

        public async Task<int> GetIdBySerialNumber(string serialNumber)
        {
            return await _context.Set<SerialNumberDetail>()
                .Where(e => e.SerialNumber == serialNumber)
                .Select(e => e.ID)
                .FirstOrDefaultAsync();
        }

        public async Task<List<int>> GetIdsByOrganizationIdAsync(int organizationId)
        {
            return await _context.Set<SubscriptionItem>()
                .Where(sItem =>
                    (sItem.Invoice.InvoiceTypeId == (int)InvoiceType.Create_New_Licenses ||
                     sItem.Invoice.InvoiceTypeId == (int)InvoiceType.Move_License) &&
                    sItem.Invoice.OrganizationAccount.Id == organizationId)
                .OrderByDescending(e=>e.UpdateDate)
                .Select(sItem => sItem.SerialNumberDetailsId)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> OrganizationHasSerialNumberDetailAsync(int organizationId, int serialNumberDetailId)
        {
            var lastSubscriptionItem = await _context.Set<SubscriptionItem>()
                .Where(sItem =>
                    sItem.SerialNumberDetailsId == serialNumberDetailId &&
                    sItem.Invoice.OrganizationAccountId == organizationId)
                .OrderByDescending(sItem => sItem.UpdateDate) // or use .OrderByDescending(sItem => sItem.Id) if that's more reliable
                .Select(sItem => new
                {
                    sItem.Invoice.InvoiceTypeId
                })
                .FirstOrDefaultAsync();

            return lastSubscriptionItem != null &&
                   (lastSubscriptionItem.InvoiceTypeId == (int)InvoiceType.Create_New_Licenses ||
                    lastSubscriptionItem.InvoiceTypeId == (int)InvoiceType.Move_License);
        }

        public async Task<Pagination<SerialNumberDetail>> GetByIdsAndOrganizationId(int organizationId, List<int> ids, int pageIndex, int pageSize)
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
                .OrderByDescending(e=>e.UpdateDate)
                .Where(sDetails => ids.Contains(sDetails.ID))
                .ToListAsync();

            // It is necessary to filter the SNDetails for which the LATEST relevant Subscription Item is from the requested
            // Organization Id
            var count = sDetailsByOrgId
                .Count(snDetails => Enumerable.OrderBy(snDetails.SubscriptionItems, sItem => sItem.UpdateDate)
                    .Last().Invoice.OrganizationAccount.Id == organizationId);

            var paginatedList = sDetailsByOrgId
                .Where(snDetails => snDetails.SubscriptionItems
                    .OrderBy(sItem => sItem.UpdateDate)
                    .Last().Invoice.OrganizationAccount.Id == organizationId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new Pagination<SerialNumberDetail>(paginatedList, count, pageIndex, pageSize);
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

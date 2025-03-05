using DP_BE_LicensePortal.Context;
using DP_BE_LicensePortal.Repositories.Interfaces;

namespace DP_BE_LicensePortal.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DP_BE_LicensePortal.Model.Entities;

public class SubscriptionItemRepository : ISubscriptionItemRepository
{
    private readonly MyDbContext _context;

    public SubscriptionItemRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SubscriptionItem>> GetAllAsync()
    {
        return await _context.Set<SubscriptionItem>().ToListAsync();
    }

    public async Task<SubscriptionItem> GetByIdAsync(int id)
    {
        return await _context.Set<SubscriptionItem>().FindAsync(id);
    }

    public async Task<SubscriptionItem> AddAsync(SubscriptionItem subscriptionItem)
    {
        await _context.Set<SubscriptionItem>().AddAsync(subscriptionItem);
        await _context.SaveChangesAsync();
        return subscriptionItem;
    }

    public async Task UpdateAsync(SubscriptionItem subscriptionItem)
    {
        _context.Set<SubscriptionItem>().Update(subscriptionItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var subscriptionItem = await _context.Set<SubscriptionItem>().FindAsync(id);
        if (subscriptionItem != null)
        {
            _context.Set<SubscriptionItem>().Remove(subscriptionItem);
            await _context.SaveChangesAsync();
        }
    }
}

namespace DP_BE_LicensePortal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using DP_BE_LicensePortal.Model.Entities;

public interface ISubscriptionItemRepository
{
    Task<IEnumerable<SubscriptionItem>> GetAllAsync();
    Task<SubscriptionItem> GetByIdAsync(int id);
    Task<SubscriptionItem> AddAsync(SubscriptionItem subscriptionItem);
    Task UpdateAsync(SubscriptionItem subscriptionItem);
    Task DeleteAsync(int id);
}

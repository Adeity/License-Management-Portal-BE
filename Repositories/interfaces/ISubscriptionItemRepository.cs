namespace LicenseManagementPortal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManagementPortal.Model.Entities;

public interface ISubscriptionItemRepository
{
    Task<IEnumerable<SubscriptionItem>> GetAllAsync();
    Task<SubscriptionItem> GetByIdAsync(int id);
    Task<SubscriptionItem> AddAsync(SubscriptionItem subscriptionItem);
    Task UpdateAsync(SubscriptionItem subscriptionItem);
    Task DeleteAsync(int id);
}

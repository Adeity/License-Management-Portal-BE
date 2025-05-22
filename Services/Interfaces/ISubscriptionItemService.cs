using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.dto.output;

namespace LicenseManagementPortal.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManagementPortal.Model.Entities;

public interface ISubscriptionItemService
{
    Task<IEnumerable<SubscriptionItem>> GetAllAsync();
    Task<SubscriptionItem> GetByIdAsync(int id);
    Task<SubscriptionItemOutputDto> AddAsync(SubscriptionItemInputDto subscriptionItem);
    Task UpdateAsync(SubscriptionItemInputDto subscriptionItem);
    Task DeleteAsync(int id);
}

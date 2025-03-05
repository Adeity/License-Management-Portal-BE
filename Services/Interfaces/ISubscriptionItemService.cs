using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;

namespace DP_BE_LicensePortal.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using DP_BE_LicensePortal.Model.Entities;

public interface ISubscriptionItemService
{
    Task<IEnumerable<SubscriptionItem>> GetAllAsync();
    Task<SubscriptionItem> GetByIdAsync(int id);
    Task<SubscriptionItemOutputDto> AddAsync(SubscriptionItemInputDto subscriptionItem);
    Task UpdateAsync(SubscriptionItemInputDto subscriptionItem);
    Task DeleteAsync(int id);
}

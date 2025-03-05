using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;

namespace DP_BE_LicensePortal.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Repositories;

public class SubscriptionItemService : ISubscriptionItemService
{
    private readonly ISubscriptionItemRepository _repository;

    public SubscriptionItemService(ISubscriptionItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SubscriptionItem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<SubscriptionItem> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<SubscriptionItemOutputDto> AddAsync(SubscriptionItemInputDto subscriptionItem)
    {
        var createdEntity = await _repository.AddAsync(subscriptionItem.ToEntity());
        return createdEntity.ToOutputDto();
    }

    public async Task UpdateAsync(SubscriptionItemInputDto subscriptionItem)
    {
        await _repository.UpdateAsync(subscriptionItem.ToEntity());
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}

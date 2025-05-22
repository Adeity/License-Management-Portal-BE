using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.dto.output;
using LicenseManagementPortal.Model.Mappers;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;

namespace LicenseManagementPortal.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories;

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

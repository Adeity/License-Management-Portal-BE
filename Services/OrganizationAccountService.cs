using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using DP_BE_LicensePortal.Model.Mappers;

namespace DP_BE_LicensePortal.Services
{
    public class OrganizationAccountService : IOrganizationAccountService
    {
        private readonly IOrganizationAccountRepository _organizationAccountRepository;

        public OrganizationAccountService(IOrganizationAccountRepository organizationAccountRepository)
        {
            _organizationAccountRepository = organizationAccountRepository;
        }

        public async Task<OrganizationAccountOutputDto?> GetByIdAsync(int id)
        {
            var entity = await _organizationAccountRepository.GetByIdAsync(id);
            return entity?.ToOutputDto();
        }

        public async Task<List<SerialNumberDetailOutputDto>> GetSerialNumbersByOrganizationIdAsync(int id)
        {
            // var exists = await _organizationAccountRepository.ExistsByIdAsync(id);
            // if (!exists) return new List<SerialNumberDetailOutputDto>();

            return null;
        }

        public async Task<Pagination<OrganizationAccountOutputDto>> GetAllAsync(int pageIndex, int pageSize)
        {
            var result = await _organizationAccountRepository.GetAllAsync(pageIndex, pageSize);
            var dtoList = result.Items.Select(entity => entity.ToOutputDto()).ToList();

            return new Pagination<OrganizationAccountOutputDto>(dtoList, result.TotalItems, pageIndex, pageSize);
        }

        public async Task<OrganizationAccountOutputDto> AddAsync(OrganizationAccountInputDto dto)
        {
            var entity = dto.ToEntity();
            var savedEntity = await _organizationAccountRepository.AddAsync(entity);
            return savedEntity.ToOutputDto();
        }

        public async Task<OrganizationAccountOutputDto> UpdateAsync(int id, OrganizationAccountInputDto dto)
        {
            var existingEntity = await _organizationAccountRepository.GetByIdAsync(id);
            if (existingEntity == null) return null;

            // Update the existing entity using the DTO properties
            existingEntity.Name = dto.Name;
            existingEntity.ParentOrganizationId = dto.ParentOrganizationId;
            existingEntity.UserID = dto.UserId;
            existingEntity.AccountID = dto.AccountId;
            existingEntity.OrganizationTypeId = dto.OrganizationTypeId;
            existingEntity.UpdateDate = dto.UpdateDate;
            existingEntity.IsDeleted = dto.IsDeleted;

            var updatedEntity = await _organizationAccountRepository.UpdateAsync(id, existingEntity);
            return updatedEntity.ToOutputDto();
        }

        public async Task DeleteAsync(int id)
        {
            await _organizationAccountRepository.DeleteAsync(id);
        }

        public async Task<List<OrganizationAccountOutputDto>> GetAllByResellerIdAsync(int resellerId)
        {
            var organizations = await _organizationAccountRepository.GetAllByResellerIdAsync(resellerId);
            return organizations.Select(o => o.ToOutputDto()).ToList();
        }
    }
}

using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;
using LicenseManagementPortal.Utilities;
using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Model.Mappers;

namespace LicenseManagementPortal.Services
{
    public class OrganizationAccountService(
        IOrganizationAccountRepository organizationAccountRepository,
        IOrganizationPackageDetailsService organizationPackageDetailsService)
        : IOrganizationAccountService
    {

        public async Task<OrganizationAccountOutputDto?> GetByIdAsync(int id)
        {
            var entity = await organizationAccountRepository.GetByIdAsync(id);
            return entity?.ToOutputDto();
        }

        public async Task<Pagination<OrganizationAccountOutputDto>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await organizationAccountRepository.GetAllPaginatedAsync(pageIndex, pageSize);
            var dtoList = result.Items.Select(entity => entity.ToOutputDto()).ToList();

            return new Pagination<OrganizationAccountOutputDto>(dtoList, result.TotalItems, pageIndex, pageSize);
        }

        public async Task<OrganizationAccountOutputDto> AddAsync(OrganizationAccountInputDto dto)
        {
            var entity = dto.ToEntity();
            var savedEntity = await organizationAccountRepository.AddAsync(entity);
            return savedEntity.ToOutputDto();
        }

        public async Task<OrganizationAccountOutputDto> UpdateAsync(int id, OrganizationAccountInputDto dto)
        {
            var existingEntity = await organizationAccountRepository.GetByIdAsync(id);
            if (existingEntity == null) return null;

            // Update the existing entity using the DTO properties
            existingEntity.Name = dto.Name;
            existingEntity.ParentOrganizationId = dto.ParentOrganizationId;
            existingEntity.AccountID = dto.AccountId;
            existingEntity.OrganizationTypeId = dto.OrganizationTypeId;

            var updatedEntity = await organizationAccountRepository.UpdateAsync(id, existingEntity);
            return updatedEntity.ToOutputDto();
        }

        public async Task DeleteAsync(int id)
        {
            await organizationAccountRepository.DeleteAsync(id);
        }

        public async Task DeleteOrgPackageDetailAsync(int id, int organizationPackageDetailId)
        {
            if (!await organizationPackageDetailsService.BelongsToOrganizationAccountAsync(organizationPackageDetailId, id))
            {
                throw new UnauthorizedAccessException("You do not have permission to access this resource.");
            }

            await organizationPackageDetailsService.DeleteAsync(organizationPackageDetailId);
        }

        public async Task UpdateOrgPackageDetailCountAsync(int id, int organizationPackageDetailId, int newCount)
        {
            if (!await organizationPackageDetailsService.BelongsToOrganizationAccountAsync(organizationPackageDetailId, id))
            {
                throw new UnauthorizedAccessException("You do not have permission to access this resource.");
            }

            await organizationPackageDetailsService.UpdateSerialNumbersCountAsync(organizationPackageDetailId,
                newCount);
        }

        public async Task<bool> IsChildOrganizationOfReseller(int organizationId, int resellerId)
        {
            return await organizationAccountRepository.IsChildOrganizationOfReseller(organizationId, resellerId);
        }
    }
}

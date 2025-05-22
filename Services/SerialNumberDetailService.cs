using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;
using LicenseManagementPortal.Utilities;
using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Model.Mappers;

namespace LicenseManagementPortal.Services
{
    public class SerialNumberDetailService : ISerialNumberDetailService
    {
        private readonly ISerialNumberDetailRepository _serialNumberDetailRepository;
        private readonly IOrganizationAccountRepository _organizationAccountRepository;

        public SerialNumberDetailService(ISerialNumberDetailRepository serialNumberDetailRepository,
            IOrganizationAccountRepository organizationAccountRepository
            )
        {
            _serialNumberDetailRepository = serialNumberDetailRepository;
            _organizationAccountRepository = organizationAccountRepository;
        }

        public async Task<SerialNumberDetailOutputDto> GetByIdAsync(int id)
        {
            var entity = await _serialNumberDetailRepository.GetByIdAsync(id);
            return entity != null ? entity.ToOutputDto() : null;
        }

        public async Task<int> GetIdBySerialNumber(string serialNumber)
        {
            var id = await _serialNumberDetailRepository.GetIdBySerialNumber(serialNumber);
            return id;
        }

        public async Task<Pagination<SerialNumberDetailOutputDto>> GetAllAsync(int pageIndex, int pageSize)
        {
            var result = await _serialNumberDetailRepository.GetAllAsync(pageIndex, pageSize);
            var dtoList = result.Items.Select(entity => entity.ToOutputDto()).ToList();


            return new Pagination<SerialNumberDetailOutputDto>(dtoList, result.TotalItems, pageIndex, pageSize);
        }

        public async Task<SerialNumberDetailOutputDto> AddAsync(SerialNumberDetailInputDto dto)
        {
            var entity = dto.ToEntity();
            var savedEntity = await _serialNumberDetailRepository.AddAsync(entity);
            return savedEntity.ToOutputDto();
        }

        /// <summary>
        /// Service that Gets the Organization Details Information
        /// </summary>
        /// <param name="organizationId">Organizations Id to fetch from DataBase</param>
        /// <returns></returns>
        public async Task<Pagination<LicenseTableDto>> GetOrganizationsLicenses(int organizationId, int pageIndex, int pageSize)
        {
            var sNDetailsIdByOrgId =
                await _serialNumberDetailRepository.GetIdsByOrganizationIdAsync(organizationId);
            var organizationName = await _organizationAccountRepository.GetNameByIdAsync(organizationId);
            var licensesEntities = await _serialNumberDetailRepository.GetByIdsAndOrganizationId(organizationId, sNDetailsIdByOrgId, pageIndex, pageSize);

            // var dtoList = licensesEntities.Items.Select(entity => entity.ToOutputDto()).ToList();
            var dtoList = licensesEntities.Items.Select(licenseEntity => licenseEntity.ToLicenseTableDto(organizationName)).ToList();

            return new Pagination<LicenseTableDto>(dtoList, licensesEntities.TotalItems, pageIndex, pageSize);
        }

        public async Task<SerialNumberDetailOutputDto> UpdateAsync(int id, SerialNumberDetailInputDto dto)
        {
            var existingEntity = await _serialNumberDetailRepository.GetByIdAsync(id);
            if (existingEntity == null) return null;

            // Update entity properties from DTO
            existingEntity.AccountID = dto.AccountId;
            existingEntity.SerialNumberRequestLogID = dto.SerialNumberRequestLogId;
            existingEntity.IsValid = dto.IsValid;
            existingEntity.Prefix = dto.Prefix;
            existingEntity.ExpirationDate = dto.ExpirationDate;
            existingEntity.ResellerInvoiceLastRenew = dto.ResellerInvoiceLastRenew;
            existingEntity.IsTemp = dto.IsTemp;
            existingEntity.ResellerInvoice = dto.ResellerInvoice;
            existingEntity.ResellerAccount = dto.ResellerAccount;
            existingEntity.ProductNumber = dto.ProductNumber;
            existingEntity.SerialNumber = dto.SerialNumber;
            existingEntity.UpdateDate = dto.UpdateDate;
            existingEntity.LatestModificationDate = dto.LatestModificationDate;
            existingEntity.ResellerCode = dto.ResellerCode;

            var updatedEntity = await _serialNumberDetailRepository.UpdateAsync(id, existingEntity);
            return updatedEntity.ToOutputDto();
        }

        public async Task DeleteAsync(int id)
        {
            await _serialNumberDetailRepository.DeleteAsync(id);
        }
    }
}

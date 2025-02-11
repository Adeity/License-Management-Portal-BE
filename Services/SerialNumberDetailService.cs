using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;
using System.Threading.Tasks;
using System.Linq;
using DP_BE_LicensePortal.Model.dto;
using DP_BE_LicensePortal.Model.Mappers;

namespace DP_BE_LicensePortal.Services
{
    public class SerialNumberDetailService : ISerialNumberDetailService
    {
        private readonly ISerialNumberDetailRepository _serialNumberDetailRepository;
        private readonly IOrganizationAccountRepository _organizationAccountRepository;
        private readonly IPackageDetailRepository _packageDetailRepository;

        public SerialNumberDetailService(ISerialNumberDetailRepository serialNumberDetailRepository, IOrganizationAccountRepository organizationAccountRepository, IPackageDetailRepository packageDetailRepository)
        {
            _serialNumberDetailRepository = serialNumberDetailRepository;
            _organizationAccountRepository = organizationAccountRepository;
            _packageDetailRepository = packageDetailRepository;
        }

        public async Task<SerialNumberDetailOutputDto> GetByIdAsync(int id)
        {
            var entity = await _serialNumberDetailRepository.GetByIdAsync(id);
            return entity != null ? entity.ToOutputDto() : null;
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
        public async Task<List<LicenseTableDTO>> GetOrganizationsLicenses(int organizationId)
        {
            var sNDetailsIdByOrgId =
                await _serialNumberDetailRepository.GetIdsByOrganizationIdAsync(organizationId);
            var organizationName = await _organizationAccountRepository.GetNameByIdAsync(organizationId);
            var licensesEntities =   await _serialNumberDetailRepository.GetByIdsAndOrganizationId(organizationId, sNDetailsIdByOrgId);
            return licensesEntities.Select(licenseEntity => licenseEntity.ToLicenseTableDto(organizationName)).ToList();
        }

        public async Task GenerateLicense(GenerateLicenseInputDto dto)
        {
            var packageDetail = await _packageDetailRepository.GetByIdAsync(dto.PackageDetailsId);
            var organizationAccount = await _organizationAccountRepository.GetByIdAsync(dto.OrganizationAccountId);
            var quantityOfLicensesToGenerate = dto.QuantityOfLicenses;
            
            
        }

        public async Task<SerialNumberDetailOutputDto> UpdateAsync(int id, SerialNumberDetailInputDto dto)
        {
            var existingEntity = await _serialNumberDetailRepository.GetByIdAsync(id);
            if (existingEntity == null) return null;

            // Update entity properties from DTO
            existingEntity.AccountID = dto.AccountId;
            existingEntity.SerialNumberRequestLogId = dto.SerialNumberRequestLogId;
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

using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;
using System.Threading.Tasks;
using System.Linq;
using DP_BE_LicensePortal.Model.Mappers;

namespace DP_BE_LicensePortal.Services
{
    public class SerialNumberDetailService : ISerialNumberDetailService
    {
        private readonly ISerialNumberDetailRepository _serialNumberDetailRepository;

        public SerialNumberDetailService(ISerialNumberDetailRepository serialNumberDetailRepository)
        {
            _serialNumberDetailRepository = serialNumberDetailRepository;
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

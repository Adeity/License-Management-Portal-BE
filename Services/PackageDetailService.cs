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
    public class PackageDetailService : IPackageDetailService
    {
        private readonly IPackageDetailRepository _packageDetailRepository;

        public PackageDetailService(IPackageDetailRepository packageDetailRepository)
        {
            _packageDetailRepository = packageDetailRepository;
        }

        public async Task<PackageDetailOutputDto> GetByIdAsync(int id)
        {
            var entity = await _packageDetailRepository.GetByIdAsync(id);
            return entity?.ToOutputDto();
        }

        public async Task<Pagination<PackageDetailOutputDto>> GetAllAsync(int pageIndex, int pageSize)
        {
            var result = await _packageDetailRepository.GetAllAsync(pageIndex, pageSize);
            var dtoList = result.Items.Select(entity => entity.ToOutputDto()).ToList();

            return new Pagination<PackageDetailOutputDto>(dtoList, result.TotalItems, pageIndex, pageSize);
        }

        public async Task<PackageDetailOutputDto> AddAsync(PackageDetailInputDto dto)
        {
            var entity = dto.ToEntity();
            var savedEntity = await _packageDetailRepository.AddAsync(entity);
            return savedEntity.ToOutputDto();
        }

        public async Task<PackageDetailOutputDto> UpdateAsync(int id, PackageDetailInputDto dto)
        {
            var existingEntity = await _packageDetailRepository.GetByIdAsync(id);
            if (existingEntity == null) return null;

            // Update the existing entity using the DTO properties
            existingEntity.Flags = dto.Flags;
            existingEntity.ProductNumber = dto.ProductNumber;
            existingEntity.Legacy = dto.Legacy;
            existingEntity.Prefix = dto.Prefix;
            existingEntity.ProductName = dto.ProductName;
            existingEntity.LegacyPlus = dto.LegacyPlus;
            existingEntity.Current = dto.Current;
            existingEntity.Title = dto.Title;
            existingEntity.UpdateDate = dto.UpdateDate;
            existingEntity.RoleKeyId = dto.RoleKeyId;
            existingEntity.Engineering = dto.Engineering;
            existingEntity.Subscription = dto.Subscription;
            existingEntity.Advanced = dto.Advanced;
            existingEntity.Hybrid = dto.Hybrid;

            var updatedEntity = await _packageDetailRepository.UpdateAsync(id, existingEntity);
            return updatedEntity.ToOutputDto();
        }

        public async Task DeleteAsync(int id)
        {
            await _packageDetailRepository.DeleteAsync(id);
        }
    }
}

using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.dto.output;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;
using LicenseManagementPortal.Utilities;
using System.Threading.Tasks;
using System.Linq;
using LicenseManagementPortal.Model.Mappers;

namespace LicenseManagementPortal.Services
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

        public async Task<Pagination<PackageDetailOutputDto>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {
            var result = await _packageDetailRepository.GetAllPaginatedAsync(pageIndex, pageSize);
            var dtoList = result.Items.Select(entity => entity.ToOutputDto()).ToList();

            return new Pagination<PackageDetailOutputDto>(dtoList, result.TotalItems, pageIndex, pageSize);
        }

        public async Task<IEnumerable<PackageDetailOutputDto>> GetAllAsync()
        {
            var result = await _packageDetailRepository.GetAllAsync();
            var dtoList = result.Select(entity => entity.ToOutputDto()).ToList();

            return dtoList;
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

using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Services.Interfaces;

public interface IPackageDetailService
{
    Task<PackageDetailOutputDto> GetByIdAsync(int id);
    Task<Pagination<PackageDetailOutputDto>> GetAllPaginatedAsync(int pageIndex, int pageSize);
    Task<IEnumerable<PackageDetailOutputDto>> GetAllAsync();
    Task<PackageDetailOutputDto> AddAsync(PackageDetailInputDto dto);
    Task<PackageDetailOutputDto> UpdateAsync(int id, PackageDetailInputDto dto);
    Task DeleteAsync(int id);
}
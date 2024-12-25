using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Services.Interfaces;

public interface IPackageDetailService
{
    Task<PackageDetailOutputDto> GetByIdAsync(int id);
    Task<Pagination<PackageDetailOutputDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<PackageDetailOutputDto> AddAsync(PackageDetailInputDto dto);
    Task<PackageDetailOutputDto> UpdateAsync(int id, PackageDetailInputDto dto);
    Task DeleteAsync(int id);
}

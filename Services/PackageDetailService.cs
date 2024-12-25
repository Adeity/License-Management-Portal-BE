using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Services;

public class PackageDetailService : IPackageDetailService
{
    private readonly IPackageDetailRepository _packageDetailRepository;

    public PackageDetailService(IPackageDetailRepository packageDetailRepository)
    {
        _packageDetailRepository = packageDetailRepository;
    }

    public async Task<PackageDetailOutputDto> GetByIdAsync(int id)
    {
        return await _packageDetailRepository.GetByIdAsync(id);
    }

    public async Task<Pagination<PackageDetailOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        return await _packageDetailRepository.GetAllAsync(pageIndex, pageSize);
    }

    public async Task<PackageDetailOutputDto> AddAsync(PackageDetailInputDto dto)
    {
        return await _packageDetailRepository.AddAsync(dto);
    }

    public async Task<PackageDetailOutputDto> UpdateAsync(int id, PackageDetailInputDto dto)
    {
        return await _packageDetailRepository.UpdateAsync(id, dto);
    }

    public async Task DeleteAsync(int id)
    {
        await _packageDetailRepository.DeleteAsync(id);
    }
}
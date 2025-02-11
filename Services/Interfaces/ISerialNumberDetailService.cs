using DP_BE_LicensePortal.Model.dto;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Services.Interfaces;

public interface ISerialNumberDetailService
{
    Task<SerialNumberDetailOutputDto> GetByIdAsync(int id);
    Task<Pagination<SerialNumberDetailOutputDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<SerialNumberDetailOutputDto> AddAsync(SerialNumberDetailInputDto dto);
    Task<List<LicenseTableDTO>> GetOrganizationsLicenses(int organizationId);
    Task GenerateLicense(GenerateLicenseInputDto dto);
    Task<SerialNumberDetailOutputDto> UpdateAsync(int id, SerialNumberDetailInputDto dto);
    Task DeleteAsync(int id);
}
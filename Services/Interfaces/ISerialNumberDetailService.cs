using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Services.Interfaces;

public interface ISerialNumberDetailService
{
    Task<SerialNumberDetailOutputDto> GetByIdAsync(int id);
    Task<int> GetIdBySerialNumber(string serialNumber);
    Task<Pagination<SerialNumberDetailOutputDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<SerialNumberDetailOutputDto> AddAsync(SerialNumberDetailInputDto dto);
    Task<Pagination<LicenseTableDto>> GetOrganizationsLicenses(int organizationId, int pageIndex, int pageSize);
    Task<SerialNumberDetailOutputDto> UpdateAsync(int id, SerialNumberDetailInputDto dto);
    Task DeleteAsync(int id);
}
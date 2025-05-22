using LicenseManagementPortal.Model.dto.input;

namespace LicenseManagementPortal.Services.Interfaces;

public interface ISerialNumberRequestLogService
{
    Task<SerialNumberRequestLogOutputDto> AddAsync(SerialNumberRequestLogInputDto dto);
}
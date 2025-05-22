using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Model.Mappers;
using LicenseManagementPortal.Repositories;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;

namespace LicenseManagementPortal.Services;

public class SerialNumberRequestLogService : ISerialNumberRequestLogService
{
    private readonly ISerialNumberRequestLogRepository _serialNumberRequestLogRepository;

    public SerialNumberRequestLogService(ISerialNumberRequestLogRepository serialNumberRequestLogRepository)
    {
        _serialNumberRequestLogRepository = serialNumberRequestLogRepository;
    }
    public async Task<SerialNumberRequestLogOutputDto> AddAsync(SerialNumberRequestLogInputDto dto)
    {
        var entity = dto.ToEntity();
        var savedEntity = await _serialNumberRequestLogRepository.AddAsync(entity);
        return savedEntity.ToOutputDto();
    }
}
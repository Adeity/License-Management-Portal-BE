using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;

namespace DP_BE_LicensePortal.Services;

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
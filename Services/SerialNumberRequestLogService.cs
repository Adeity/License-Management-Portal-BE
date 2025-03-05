using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories;

namespace DP_BE_LicensePortal.Services;

public class SerialNumberRequestLogService
{
    private readonly SerialNumberRequestLogRepository _serialNumberRequestLogRepository;
    
    public SerialNumberRequestLogService(SerialNumberRequestLogRepository serialNumberRequestLogRepository)
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
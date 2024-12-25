using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Services;

public class SerialNumberDetailService : ISerialNumberDetailService
{
    private readonly ISerialNumberDetailRepository _serialNumberDetailRepository;

    public SerialNumberDetailService(ISerialNumberDetailRepository serialNumberDetailRepository)
    {
        _serialNumberDetailRepository = serialNumberDetailRepository;
    }

    public async Task<SerialNumberDetailOutputDto> GetByIdAsync(int id)
    {
        return await _serialNumberDetailRepository.GetByIdAsync(id);
    }

    public async Task<Pagination<SerialNumberDetailOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        return await _serialNumberDetailRepository.GetAllAsync(pageIndex, pageSize);
    }

    public async Task<SerialNumberDetailOutputDto> AddAsync(SerialNumberDetailInputDto dto)
    {
        return await _serialNumberDetailRepository.AddAsync(dto);
    }

    public async Task<SerialNumberDetailOutputDto> UpdateAsync(int id, SerialNumberDetailInputDto dto)
    {
        return await _serialNumberDetailRepository.UpdateAsync(id, dto);
    }

    public async Task DeleteAsync(int id)
    {
        await _serialNumberDetailRepository.DeleteAsync(id);
    }
}
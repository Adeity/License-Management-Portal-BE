using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class SerialNumberRequestLogMapper
{
    public static SerialNumberRequestLogOutputDto ToOutputDto(this SerialNumberRequestLog entity)
    {
        return new SerialNumberRequestLogOutputDto
        {
            UpdateDate = entity.UpdateDate,
            OrderdDate = entity.OrderdDate,
            RequestedSn = entity.RequestedSN,
            Id = entity.ID,
            // SerialNumberDetails = entity.SerialNumberDetails.Select(snd => snd.ToOutputDto()).ToList()
        };
    }

    public static SerialNumberRequestLog ToEntity(this SerialNumberRequestLogInputDto dto)
    {
        return new SerialNumberRequestLog
        {
            UpdateDate = dto.UpdateDate,
            OrderdDate = dto.OrderdDate,
            RequestedSN = dto.RequestedSn
        };
    }
}
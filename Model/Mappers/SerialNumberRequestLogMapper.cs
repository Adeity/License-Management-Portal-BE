using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Model.Mappers;

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
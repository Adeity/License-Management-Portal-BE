using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class SerialNumberDetailMapper
{
    public static SerialNumberDetailOutputDto ToOutputDto(this SerialNumberDetail entity)
    {
        return new SerialNumberDetailOutputDto
        {
            AccountId = entity.AccountID,
            SerialNumberRequestLogId = entity.SerialNumberRequestLogID,
            IsValid = entity.IsValid,
            Id = entity.ID,
            Prefix = entity.Prefix,
            ExpirationDate = entity.ExpirationDate,
            ResellerInvoiceLastRenew = entity.ResellerInvoiceLastRenew,
            IsTemp = entity.IsTemp,
            ResellerInvoice = entity.ResellerInvoice,
            ResellerAccount = entity.ResellerAccount,
            ProductNumber = entity.ProductNumber,
            SerialNumber = entity.SerialNumber,
            UpdateDate = entity.UpdateDate,
            LatestModificationDate = entity.LatestModificationDate,
            ResellerCode = entity.ResellerCode,
            SerialNumberRequestLog = entity.SerialNumberRequestLog.ToOutputDto()
        };
    }

    public static SerialNumberDetail ToEntity(this SerialNumberDetailInputDto dto)
    {
        return new SerialNumberDetail
        {
            AccountID = dto.AccountId,
            SerialNumberRequestLogID = dto.SerialNumberRequestLogId,
            IsValid = dto.IsValid,
            Prefix = dto.Prefix,
            ExpirationDate = dto.ExpirationDate,
            ResellerInvoiceLastRenew = dto.ResellerInvoiceLastRenew,
            IsTemp = dto.IsTemp,
            ResellerInvoice = dto.ResellerInvoice,
            ResellerAccount = dto.ResellerAccount,
            ProductNumber = dto.ProductNumber,
            SerialNumber = dto.SerialNumber,
            UpdateDate = dto.UpdateDate,
            LatestModificationDate = dto.LatestModificationDate,
            ResellerCode = dto.ResellerCode
        };
    }
}
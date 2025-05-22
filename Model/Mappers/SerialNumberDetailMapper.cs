using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Model.Mappers;

public static class SerialNumberDetailMapper
{
    /// <summary>
    /// Method to check Status of the Serial Number Detail
    /// </summary>
    /// <param name="snDetail">Entity of Serial Number Detail</param>
    /// <returns></returns>
    public static string GetStatusOfSerialNumber(SerialNumberDetail snDetail)
    {
        string status = "Active";
        if (snDetail.ExpirationDate < DateTime.Now)
        {
            status = "Expired"; //Expired
        }
        return status;
    }


    public static LicenseTableDto ToLicenseTableDto(this SerialNumberDetail entity, string? organizationName)
    {
        return new LicenseTableDto
        {
            id = entity.ID.ToString(),
            Expires = entity.ExpirationDate,
            Product_Number = entity.ProductNumber,
            Serial_Number = entity.SerialNumber,
            Organization = organizationName,
            Status = GetStatusOfSerialNumber(entity),
        };
    }

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
            // SerialNumberRequestLog = entity.SerialNumberRequestLog?.ToOutputDto()
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
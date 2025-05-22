namespace LicenseManagementPortal.Model.Mappers;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.dto.output;
using LicenseManagementPortal.Model.Entities;

public static class SubscriptionItemMapper
{
    public static SubscriptionItemOutputDto ToOutputDto(this SubscriptionItem entity)
    {
        return new SubscriptionItemOutputDto
        {
            Id = entity.Id,
            InvoiceId = entity.InvoiceId,
            SerialNumberDetailsId = entity.SerialNumberDetailsId,
            EMailSentCount = entity.EMailSentCount,
            UserID = entity.UserID,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SubscriptionItem ToEntity(this SubscriptionItemInputDto dto)
    {
        return new SubscriptionItem
        {
            InvoiceId = dto.InvoiceId,
            SerialNumberDetailsId = dto.SerialNumberDetailsId,
            EMailSentCount = dto.EMailSentCount,
            UserID = dto.UserID,
            UpdateDate = dto.UpdateDate
        };
    }
}

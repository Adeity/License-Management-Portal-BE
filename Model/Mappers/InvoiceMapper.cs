using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Model.Mappers;

public static class InvoiceMapper
{
    public static InvoiceOutputDto ToOutputDto(this Invoice entity)
    {
        return new InvoiceOutputDto
        {
            InvoiceTypeId = entity.InvoiceTypeId,
            Id = entity.Id,
            OrganizationAccountId = entity.OrganizationAccountId,
            UpdateDate = entity.UpdateDate,
            InvoiceType = entity.InvoiceType?.ToOutputDto(),
            // OrganizationAccount = entity.OrganizationAccount.ToOutputDto()
        };
    }

    public static Invoice ToEntity(this InvoiceInputDto dto)
    {
        return new Invoice
        {
            InvoiceTypeId = (int)dto.InvoiceTypeId,
            OrganizationAccountId = dto.OrganizationAccountId,
            UpdateDate = dto.UpdateDate
        };
    }
}
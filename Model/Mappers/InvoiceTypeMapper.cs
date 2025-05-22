using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Model.Mappers;

public static class InvoiceTypeMapper
{
    public static InvoiceTypeOutputDto ToOutputDto(this InvoiceType entity)
    {
        return new InvoiceTypeOutputDto
        {
            Description = entity.Description,
            UpdateDate = entity.UpdateDate,
            Name = entity.Name,
            Id = entity.Id,
            Invoices = entity.Invoices.Select(i => i.ToOutputDto()).ToList()
        };
    }

    public static InvoiceType ToEntity(this InvoiceTypeInputDto dto)
    {
        return new InvoiceType
        {
            Description = dto.Description,
            UpdateDate = dto.UpdateDate,
            Name = dto.Name
        };
    }
}
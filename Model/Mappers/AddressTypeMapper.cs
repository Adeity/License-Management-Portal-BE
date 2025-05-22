using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.dto.output;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Model.Mappers;

public static class AddressTypeMapper
{
    public static AddressTypeOutputDto ToOutputDto(this AddressType entity)
    {
        return new AddressTypeOutputDto
        {
            Description = entity.Description,
            UpdateDate = entity.UpdateDate,
            Name = entity.Name,
            Id = entity.Id,
            OrganizationAddresses = entity.OrganizationAddresses.Select(oa => oa.ToOutputDto()).ToList()
        };
    }

    public static AddressType ToEntity(this AddressTypeInputDto dto)
    {
        return new AddressType
        {
            Description = dto.Description,
            UpdateDate = dto.UpdateDate,
            Name = dto.Name
        };
    }
}
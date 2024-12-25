using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

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

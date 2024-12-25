using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class CountryMapper
{
    public static CountryOutputDto ToOutputDto(this Country entity)
    {
        return new CountryOutputDto
        {
            UpdateDate = entity.UpdateDate,
            Id = entity.Id,
            SelectOrder = entity.SelectOrder,
            Name = entity.Name,
            OrganizationAddresses = entity.OrganizationAddresses.Select(oa => oa.ToOutputDto()).ToList()
        };
    }

    public static Country ToEntity(this CountryInputDto dto)
    {
        return new Country
        {
            UpdateDate = dto.UpdateDate,
            SelectOrder = dto.SelectOrder,
            Name = dto.Name
        };
    }
}
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.dto.output;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Model.Mappers;

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
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class OrganizationTypeMapper
{
    public static OrganizationTypeOutputDto ToOutputDto(this OrganizationType entity)
    {
        return new OrganizationTypeOutputDto
        {
            UpdateDate = entity.UpdateDate,
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            OrganizationAccounts = entity.OrganizationAccounts.Select(oa => oa.ToOutputDto()).ToList()
        };
    }

    public static OrganizationType ToEntity(this OrganizationTypeInputDto dto)
    {
        return new OrganizationType
        {
            UpdateDate = dto.UpdateDate,
            Name = dto.Name,
            Description = dto.Description
        };
    }
}
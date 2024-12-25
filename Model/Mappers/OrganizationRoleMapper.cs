using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class OrganizationRoleMapper
{
    public static OrganizationRoleOutputDto ToOutputDto(this OrganizationRole entity)
    {
        return new OrganizationRoleOutputDto
        {
            Name = entity.Name,
            UpdateDate = entity.UpdateDate,
            Id = entity.Id,
            Description = entity.Description,
            OrganizationContacts = entity.OrganizationContacts.Select(oc => oc.ToOutputDto()).ToList()
        };
    }

    public static OrganizationRole ToEntity(this OrganizationRoleInputDto dto)
    {
        return new OrganizationRole
        {
            Name = dto.Name,
            UpdateDate = dto.UpdateDate,
            Description = dto.Description
        };
    }
}
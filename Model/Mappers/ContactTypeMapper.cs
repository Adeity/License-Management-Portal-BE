using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class ContactTypeMapper
{
    public static ContactTypeOutputDto ToOutputDto(this ContactType entity)
    {
        return new ContactTypeOutputDto
        {
            UpdateDate = entity.UpdateDate,
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            OrganizationContacts = entity.OrganizationContacts.Select(oc => oc.ToOutputDto()).ToList()
        };
    }

    public static ContactType ToEntity(this ContactTypeInputDto dto)
    {
        return new ContactType
        {
            UpdateDate = dto.UpdateDate,
            Name = dto.Name,
            Description = dto.Description
        };
    }
}
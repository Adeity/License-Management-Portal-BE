using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class OrganizationContactMapper
{
    public static OrganizationContactOutputDto ToOutputDto(this OrganizationContact entity)
    {
        return new OrganizationContactOutputDto
        {
            OrganizationRoleId = entity.OrganizationRoleId,
            UserID = entity.UserID,
            UpdateDate = entity.UpdateDate,
            Id = entity.Id,
            OrganizationAccountId = entity.OrganizationAccountId,
            ContactTypeId = entity.ContactTypeId,
            ContactType = entity.ContactType.ToOutputDto(),
            OrganizationAccount = entity.OrganizationAccount.ToOutputDto(),
            OrganizationRole = entity.OrganizationRole.ToOutputDto(),
        };
    }

    public static OrganizationContact ToEntity(this OrganizationContactInputDto dto)
    {
        return new OrganizationContact
        {
            OrganizationRoleId = dto.OrganizationRoleId,
            UserID = dto.UserID,
            UpdateDate = dto.UpdateDate,
            OrganizationAccountId = dto.OrganizationAccountId,
            ContactTypeId = dto.ContactTypeId
        };
    }
}
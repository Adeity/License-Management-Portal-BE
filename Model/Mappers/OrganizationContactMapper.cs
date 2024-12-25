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
            UserId = entity.UserId,
            UpdateDate = entity.UpdateDate,
            Id = entity.Id,
            OrganizationAccountId = entity.OrganizationAccountId,
            ContactTypeId = entity.ContactTypeId,
            ContactType = entity.ContactType.ToOutputDto(),
            OrganizationAccount = entity.OrganizationAccount.ToOutputDto(),
            OrganizationRole = entity.OrganizationRole.ToOutputDto(),
            User = entity.User?.ToOutputDto()
        };
    }

    public static OrganizationContact ToEntity(this OrganizationContactInputDto dto)
    {
        return new OrganizationContact
        {
            OrganizationRoleId = dto.OrganizationRoleId,
            UserId = dto.UserId,
            UpdateDate = dto.UpdateDate,
            OrganizationAccountId = dto.OrganizationAccountId,
            ContactTypeId = dto.ContactTypeId
        };
    }
}
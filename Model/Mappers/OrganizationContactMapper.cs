using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Model.Mappers;

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
            // ContactType = entity.ContactType.ToOutputDto(),
            // OrganizationAccount = entity.OrganizationAccount.ToOutputDto(),
            // OrganizationRole = entity.OrganizationRole.ToOutputDto(),
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
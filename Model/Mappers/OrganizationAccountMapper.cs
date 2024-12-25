using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class OrganizationAccountMapper
{
    public static OrganizationAccountOutputDto ToOutputDto(this OrganizationAccount entity)
    {
        return new OrganizationAccountOutputDto
        {
            Name = entity.Name,
            ParentOrganizationId = entity.ParentOrganizationId,
            UserId = entity.UserId,
            AccountId = entity.AccountId,
            Id = entity.Id,
            OrganizationTypeId = entity.OrganizationTypeId,
            UpdateDate = entity.UpdateDate,
            IsDeleted = entity.IsDeleted,
            InverseParentOrganization = entity.InverseParentOrganization.Select(ipo => ipo.ToOutputDto()).ToList(),
            Invoices = entity.Invoices.Select(i => i.ToOutputDto()).ToList(),
            OrganizationAddresses = entity.OrganizationAddresses.Select(oa => oa.ToOutputDto()).ToList(),
            OrganizationContacts = entity.OrganizationContacts.Select(oc => oc.ToOutputDto()).ToList(),
            OrganizationPackageDetails = entity.OrganizationPackageDetails.Select(opd => opd.ToOutputDto()).ToList(),
            OrganizationType = entity.OrganizationType.ToOutputDto(),
            ParentOrganization = entity.ParentOrganization?.ToOutputDto()
        };
    }

    public static OrganizationAccount ToEntity(this OrganizationAccountInputDto dto)
    {
        return new OrganizationAccount
        {
            Name = dto.Name,
            ParentOrganizationId = dto.ParentOrganizationId,
            UserId = dto.UserId,
            AccountId = dto.AccountId,
            OrganizationTypeId = dto.OrganizationTypeId,
            UpdateDate = dto.UpdateDate,
            IsDeleted = dto.IsDeleted
        };
    }
}
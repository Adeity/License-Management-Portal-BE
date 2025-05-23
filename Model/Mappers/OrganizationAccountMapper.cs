﻿using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Model.Mappers;

public static class OrganizationAccountMapper
{
    public static OrganizationAccountOutputDto ToOutputDto(this OrganizationAccount entity)
    {
        return new OrganizationAccountOutputDto
        {
            Name = entity.Name,
            ParentOrganizationId = entity.ParentOrganizationId,
            // UserId = entity.UserID,
            AccountId = entity.AccountID,
            Id = entity.Id,
            OrganizationTypeId = entity.OrganizationTypeId,
            UpdateDate = entity.UpdateDate,
            IsDeleted = entity.IsDeleted,
            // InverseParentOrganization = entity.InverseParentOrganization.Select(ipo => ipo.ToOutputDto()).ToList(),
            // Invoices = entity.Invoices.Select(i => i.ToOutputDto()).ToList(),
            OrganizationAddress = entity.OrganizationAddress?.ToOutputDto(),
            OrganizationContacts = entity.OrganizationContacts.Select(oc => oc.ToOutputDto()).ToList(),
            OrganizationPackageDetails = entity.OrganizationPackageDetails.Select(opd => opd.ToOutputDto()).ToList(),
            OrganizationType = entity.OrganizationType?.Name,
            // OrganizationType = entity.OrganizationType?.ToOutputDto(),
            ParentOrganization = entity.ParentOrganization?.Name
        };
    }

    public static OrganizationAccount ToEntity(this OrganizationAccountInputDto dto)
    {
        return new OrganizationAccount
        {
            Name = dto.Name,
            ParentOrganizationId = dto.ParentOrganizationId,
            // UserID = dto.UserId,
            AccountID = dto.AccountId,
            OrganizationTypeId = dto.OrganizationTypeId,
            // UpdateDate = dto.UpdateDate,
            // IsDeleted = dto.IsDeleted
        };
    }
}
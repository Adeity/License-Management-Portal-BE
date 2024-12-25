using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class OrganizationAddressMapper
{
    public static OrganizationAddressOutputDto ToOutputDto(this OrganizationAddress entity)
    {
        return new OrganizationAddressOutputDto
        {
            PostalCode = entity.PostalCode,
            Id = entity.Id,
            AddressTypeId = entity.AddressTypeId,
            OrganizationAccountId = entity.OrganizationAccountId,
            UpdateDate = entity.UpdateDate,
            State = entity.State,
            Address2 = entity.Address2,
            Address3 = entity.Address3,
            City = entity.City,
            CountryId = entity.CountryId,
            Address = entity.Address,
            AddressType = entity.AddressType.ToOutputDto(),
            Country = entity.Country.ToOutputDto(),
            OrganizationAccount = entity.OrganizationAccount.ToOutputDto()
        };
    }

    public static OrganizationAddress ToEntity(this OrganizationAddressInputDto dto)
    {
        return new OrganizationAddress
        {
            PostalCode = dto.PostalCode,
            AddressTypeId = dto.AddressTypeId,
            OrganizationAccountId = dto.OrganizationAccountId,
            UpdateDate = dto.UpdateDate,
            State = dto.State,
            Address2 = dto.Address2,
            Address3 = dto.Address3,
            City = dto.City,
            CountryId = dto.CountryId,
            Address = dto.Address
        };
    }
}
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class OrganizationPackageDetailMapper
{
    public static OrganizationPackageDetailOutputDto ToOutputDto(this OrganizationPackageDetail entity)
    {
        return new OrganizationPackageDetailOutputDto
        {
            Id = entity.Id,
            SerialNumbersCount = entity.SerialNumbersCount,
            UpdateDate = entity.UpdateDate,
            PackageDetailsId = entity.PackageDetailsId,
            OrganizationAccountId = entity.OrganizationAccountId,
            OrganizationAccount = entity.OrganizationAccount.ToOutputDto(),
            PackageDetails = entity.PackageDetails.ToOutputDto()
        };
    }

    public static OrganizationPackageDetail ToEntity(this OrganizationPackageDetailInputDto dto)
    {
        return new OrganizationPackageDetail
        {
            SerialNumbersCount = dto.SerialNumbersCount,
            UpdateDate = dto.UpdateDate,
            PackageDetailsId = dto.PackageDetailsId,
            OrganizationAccountId = dto.OrganizationAccountId
        };
    }
}
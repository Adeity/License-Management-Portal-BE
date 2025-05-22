using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Model.Mappers;

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
            // OrganizationAccount = entity.OrganizationAccount.ToOutputDto(),
            PackageDetailId = entity.PackageDetailsId,
            PackageDetailTitle = entity.PackageDetails?.Title,
            // PackageDetails = entity.PackageDetails.ToOutputDto()
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
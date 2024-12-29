using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class PackageDetailMapper
{
    public static PackageDetailOutputDto ToOutputDto(this PackageDetail entity)
    {
        return new PackageDetailOutputDto
        {
            Id = entity.ID,
            Flags = entity.Flags,
            ProductNumber = entity.ProductNumber,
            Legacy = entity.Legacy,
            Prefix = entity.Prefix,
            ProductName = entity.ProductName,
            LegacyPlus = entity.LegacyPlus,
            Current = entity.Current,
            Title = entity.Title,
            UpdateDate = entity.UpdateDate,
            RoleKeyId = entity.RoleKeyId,
            Engineering = entity.Engineering,
            Subscription = entity.Subscription,
            Advanced = entity.Advanced,
            Hybrid = entity.Hybrid,
            OrganizationPackageDetails = entity.OrganizationPackageDetails.Select(opd => opd.ToOutputDto()).ToList()
        };
    }

    public static PackageDetail ToEntity(this PackageDetailInputDto dto)
    {
        return new PackageDetail
        {
            Flags = dto.Flags,
            ProductNumber = dto.ProductNumber,
            Legacy = dto.Legacy,
            Prefix = dto.Prefix,
            ProductName = dto.ProductName,
            LegacyPlus = dto.LegacyPlus,
            Current = dto.Current,
            Title = dto.Title,
            UpdateDate = dto.UpdateDate,
            RoleKeyId = dto.RoleKeyId,
            Engineering = dto.Engineering,
            Subscription = dto.Subscription,
            Advanced = dto.Advanced,
            Hybrid = dto.Hybrid
        };
    }
}
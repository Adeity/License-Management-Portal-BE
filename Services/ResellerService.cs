using LicenseManagementPortal.Model.database;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Mappers;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;
using LicenseManagementPortal.Utilities;
using Microsoft.AspNetCore.Identity;

namespace LicenseManagementPortal.Services;

public class ResellerService : IResellerService
{
    private readonly IOrganizationAccountRepository _organizationAccountRepository;
    private readonly IOrganizationPackageDetailsRepository _organizationPackageDetailsRepository;

    public ResellerService(
        IOrganizationAccountRepository organizationAccountRepository,
        IOrganizationPackageDetailsRepository organizationPackageDetailsRepository
        )
    {
        _organizationAccountRepository = organizationAccountRepository;
        _organizationPackageDetailsRepository = organizationPackageDetailsRepository;
    }

    public async Task<List<OrganizationAccountOutputDto>> GetAllResellers()
    {
        var result = await _organizationAccountRepository.GetAllWithoutParentIdAsync();
        var dtoList = result.Select(entity => entity.ToOutputDto()).ToList();

        return dtoList;
    }

    public async Task<OrganizationAccountOutputDto> GetLoggedUserReseller(int resellerId)
    {
        var reseller = await _organizationAccountRepository.GetByIdAsync(resellerId);
        if (reseller == null)
        {
            throw new KeyNotFoundException("Reseller organization account not found for logged user.");
        }

        return reseller.ToOutputDto();
    }

    public async Task<Pagination<OrganizationAccountOutputDto>> GetChildOrganizationsPaginated(int resellerId, int pageIndex, int pageSize)
    {
        var childOrgs = await _organizationAccountRepository.GetAllByResellerIdPaginatedAsync(resellerId, pageIndex, pageSize);

        var dtoList = childOrgs.Items.Select(entity => entity.ToOutputDto()).ToList();

        return new Pagination<OrganizationAccountOutputDto>(dtoList, childOrgs.TotalItems, pageIndex, pageSize);
    }

    public async Task<IEnumerable<OrganizationAccountOutputDto>> GetChildOrganizations(int resellerId)
    {
        var childOrgs = await _organizationAccountRepository.GetAllByResellerIdAsync(resellerId);

        var dtoList = childOrgs.Select(entity => entity.ToOutputDto()).ToList();

        return dtoList;
    }

    public async Task<IEnumerable<OrganizationPackageDetailOutputDto>> GetResellerPackageDetails(int resellerId)
    {
        var orgPackageDetails = await _organizationPackageDetailsRepository.GetByOrganizationAccountId(resellerId);
        var dtoList = orgPackageDetails.Select(entity => entity.ToOutputDto()).ToList();
        return dtoList;
    }
}
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Services.Interfaces;

public interface IResellerService
{
    Task<List<OrganizationAccountOutputDto>> GetAllResellers();
    Task<Pagination<OrganizationAccountOutputDto>> GetChildOrganizationsPaginated(int resellerId, int pageIndex, int pageSize);
    Task<IEnumerable<OrganizationAccountOutputDto>> GetChildOrganizations(int resellerId);
    Task<IEnumerable<OrganizationPackageDetailOutputDto>> GetResellerPackageDetails(int resellerId);
}

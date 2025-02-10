using DP_BE_LicensePortal.Model.dto.input;

namespace DP_BE_LicensePortal.Services.Interfaces;

public interface IResellerService
{
    Task<List<OrganizationAccountOutputDto>> GetAllResellers();
}

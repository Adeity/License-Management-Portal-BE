using LicenseManagementPortal.Model.dto.input;

namespace LicenseManagementPortal.Services.Interfaces;

public interface ILicenseActionsService
{
    Task<SerialNumberDetailOutputDto> GenerateLicense(GenerateLicenseInputDto dto, int resellerOrgAccountId);
    Task MoveLicense(MoveLicenseInputDto dto);
}
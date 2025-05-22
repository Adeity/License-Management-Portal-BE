using LicenseManagementPortal.Model.dto.input;

namespace LicenseManagementPortal.Services.Interfaces;

public interface IOrganizationContactService
{
    Task<OrganizationContactOutputDto?> GetByAspNetUserId(string aspNetUserId);
}
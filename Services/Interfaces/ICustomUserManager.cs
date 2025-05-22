using System.Security.Claims;

namespace LicenseManagementPortal.Services.Interfaces;

public interface ICustomUserManager
{
    Task<int?> GetOrgByPrincipalAsync(ClaimsPrincipal principal);
}
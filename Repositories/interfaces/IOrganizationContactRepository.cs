using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Repositories.Interfaces;

public interface IOrganizationContactRepository
{
    Task<OrganizationContact?> GetByAspNetUserId(string userId);
}
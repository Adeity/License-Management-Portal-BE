using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;

namespace LicenseManagementPortal.Repositories.Interfaces;

public interface IOrganizationTypeRepository
{
    Task<OrganizationType?> GetByIdAsync(int id);
    Task<List<OrganizationType>> GetAll();
}
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Repositories.Interfaces;

public interface IInvoiceRepository
{
    Task<Invoice?> GetByIdAsync(int id);
    Task<Pagination<Invoice>> GetAllAsync(int pageIndex, int pageSize);
    Task<Invoice> AddAsync(Invoice entity);
    Task<Invoice> UpdateAsync(int id, Invoice entity);
    Task DeleteAsync(int id);
}
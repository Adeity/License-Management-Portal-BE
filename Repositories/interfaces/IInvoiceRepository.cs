using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Repositories.Interfaces;

public interface IInvoiceRepository
{
    Task<Invoice?> GetByIdAsync(int id);
    Task<Pagination<Invoice>> GetAllAsync(int pageIndex, int pageSize);
    Task<Invoice> AddAsync(Invoice dto);
    Task<Invoice> UpdateAsync(int id, Invoice dto);
    Task DeleteAsync(int id);
}
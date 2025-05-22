using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Services.Interfaces;

public interface IInvoiceService
{
    Task<InvoiceOutputDto> GetByIdAsync(int id);
    Task<Pagination<InvoiceOutputDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<InvoiceOutputDto> AddAsync(InvoiceInputDto dto);
    Task<InvoiceOutputDto> UpdateAsync(int id, InvoiceInputDto dto);
    Task DeleteAsync(int id);
}
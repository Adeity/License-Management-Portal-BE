using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Repositories.Interfaces;

public interface IInvoiceRepository
{
    Task<InvoiceOutputDto> GetByIdAsync(int id);
    Task<Pagination<InvoiceOutputDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<InvoiceOutputDto> AddAsync(InvoiceInputDto dto);
    Task<InvoiceOutputDto> UpdateAsync(int id, InvoiceInputDto dto);
    Task DeleteAsync(int id);
}
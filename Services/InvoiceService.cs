using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceService(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<InvoiceOutputDto> GetByIdAsync(int id)
    {
        return await _invoiceRepository.GetByIdAsync(id);
    }

    public async Task<Pagination<InvoiceOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        return await _invoiceRepository.GetAllAsync(pageIndex, pageSize);
    }

    public async Task<InvoiceOutputDto> AddAsync(InvoiceInputDto dto)
    {
        return await _invoiceRepository.AddAsync(dto);
    }

    public async Task<InvoiceOutputDto> UpdateAsync(int id, InvoiceInputDto dto)
    {
        return await _invoiceRepository.UpdateAsync(id, dto);
    }

    public async Task DeleteAsync(int id)
    {
        await _invoiceRepository.DeleteAsync(id);
    }
}
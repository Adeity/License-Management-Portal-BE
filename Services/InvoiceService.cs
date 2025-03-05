using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;
using System.Threading.Tasks;
using System.Linq;
using DP_BE_LicensePortal.Model.Mappers;

namespace DP_BE_LicensePortal.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<InvoiceOutputDto> GetByIdAsync(int id)
        {
            var entity = await _invoiceRepository.GetByIdAsync(id);
            return entity?.ToOutputDto();
        }

        public async Task<Pagination<InvoiceOutputDto>> GetAllAsync(int pageIndex, int pageSize)
        {
            var result = await _invoiceRepository.GetAllAsync(pageIndex, pageSize);
            var dtoList = result.Items.Select(entity => entity.ToOutputDto()).ToList();

            return new Pagination<InvoiceOutputDto>(dtoList, result.TotalItems, pageIndex, pageSize);
        }

        public async Task<InvoiceOutputDto> AddAsync(InvoiceInputDto dto)
        {
            Console.WriteLine("about to create netity from dto");
            var entity = dto.ToEntity();
            Console.WriteLine("created entity from dto");
            var savedEntity = await _invoiceRepository.AddAsync(entity);
            return savedEntity.ToOutputDto();
        }

        public async Task<InvoiceOutputDto> UpdateAsync(int id, InvoiceInputDto dto)
        {
            var existingEntity = await _invoiceRepository.GetByIdAsync(id);
            if (existingEntity == null) return null;

            // Update entity properties from DTO
            existingEntity.OrganizationAccountId = dto.OrganizationAccountId;
            existingEntity.InvoiceTypeId = (int) dto.InvoiceTypeId;
            existingEntity.UpdateDate = dto.UpdateDate;

            var updatedEntity = await _invoiceRepository.UpdateAsync(id, existingEntity);
            return updatedEntity.ToOutputDto();
        }

        public async Task DeleteAsync(int id)
        {
            await _invoiceRepository.DeleteAsync(id);
        }
    }
}

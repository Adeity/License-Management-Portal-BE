using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Repositories.Interfaces;

public interface IInvoiceTypeRepository
{
    Task<InvoiceType> AddAsync(InvoiceType entity);
}
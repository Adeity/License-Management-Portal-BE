using LicenseManagementPortal.Model.Enums;

namespace LicenseManagementPortal.Model.dto.input;

public class InvoiceInputDto
{
    public InvoiceType InvoiceTypeId { get; set; }
    public int OrganizationAccountId { get; set; }
    public DateTime UpdateDate { get; set; }
}
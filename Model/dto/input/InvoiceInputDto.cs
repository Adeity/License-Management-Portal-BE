using DP_BE_LicensePortal.Model.Enums;

namespace DP_BE_LicensePortal.Model.dto.input;

public class InvoiceInputDto
{
    public InvoiceTypeEnum InvoiceTypeId { get; set; }
    public int OrganizationAccountId { get; set; }
    public DateTime UpdateDate { get; set; }
}
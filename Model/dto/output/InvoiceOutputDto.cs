namespace LicenseManagementPortal.Model.dto.input;

public class InvoiceOutputDto
{
    public int InvoiceTypeId { get; set; }
    public int Id { get; set; }
    public int OrganizationAccountId { get; set; }
    public DateTime UpdateDate { get; set; }
    public InvoiceTypeOutputDto InvoiceType { get; set; } = null!;
    public OrganizationAccountOutputDto OrganizationAccount { get; set; } = null!;
}
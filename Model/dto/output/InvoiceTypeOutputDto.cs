namespace DP_BE_LicensePortal.Model.dto.input;

public class InvoiceTypeOutputDto
{
    public string Description { get; set; } = null!;
    public DateTime UpdateDate { get; set; }
    public string Name { get; set; } = null!;
    public int Id { get; set; }
    public List<InvoiceOutputDto> Invoices { get; set; } = new List<InvoiceOutputDto>();
}
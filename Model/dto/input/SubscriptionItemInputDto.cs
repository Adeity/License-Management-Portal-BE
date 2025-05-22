namespace LicenseManagementPortal.Model.dto.input;

public class SubscriptionItemInputDto
{
    public int InvoiceId { get; set; }
    public int SerialNumberDetailsId { get; set; }
    public int EMailSentCount { get; set; }
    public string UserID { get; set; } = null!;
    public DateTime UpdateDate { get; set; }
}

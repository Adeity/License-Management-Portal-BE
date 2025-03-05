namespace DP_BE_LicensePortal.Model.dto.output;

public class SubscriptionItemOutputDto
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public int SerialNumberDetailsId { get; set; }
    public int EMailSentCount { get; set; }
    public string UserID { get; set; } = null!;
    public DateTime UpdateDate { get; set; }
}

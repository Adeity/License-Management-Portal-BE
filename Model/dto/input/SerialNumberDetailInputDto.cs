namespace DP_BE_LicensePortal.Model.dto.input;

public class SerialNumberDetailInputDto
{
    public string AccountId { get; set; } = null!;
    public int SerialNumberRequestLogId { get; set; }
    public bool IsValid { get; set; }
    public string Prefix { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public string ResellerInvoiceLastRenew { get; set; } = null!;
    public bool? IsTemp { get; set; }
    public string ResellerInvoice { get; set; } = null!;
    public string ResellerAccount { get; set; } = null!;
    public string ProductNumber { get; set; } = null!;
    public string SerialNumber { get; set; } = null!;
    public DateTime UpdateDate { get; set; }
    public DateTime? LatestModificationDate { get; set; }
    public string ResellerCode { get; set; } = null!;

    public override string ToString()
    {
        return $"AccountId: {AccountId}, SerialNumberRequestLogId: {SerialNumberRequestLogId}, IsValid: {IsValid}, Prefix: {Prefix}, ExpirationDate: {ExpirationDate}, ResellerInvoiceLastRenew: {ResellerInvoiceLastRenew}, IsTemp: {IsTemp}, ResellerInvoice: {ResellerInvoice}, ResellerAccount: {ResellerAccount}, ProductNumber: {ProductNumber}, SerialNumber: {SerialNumber}, UpdateDate: {UpdateDate}, LatestModificationDate: {LatestModificationDate}, ResellerCode: {ResellerCode}";
    }
}
namespace LicenseManagementPortal.Model.dto.input;

public class OrganizationAddressInputDto
{
    public string PostalCode { get; set; } = null!;
    public int AddressTypeId { get; set; }
    public int OrganizationAccountId { get; set; }
    public DateTime UpdateDate { get; set; }
    public string State { get; set; } = null!;
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public string City { get; set; } = null!;
    public int CountryId { get; set; }
    public string Address { get; set; } = null!;
}
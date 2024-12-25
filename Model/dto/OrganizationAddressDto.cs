namespace DP_BE_LicensePortal.Entities.Dto;

public class OrganizationAddressDto
{
    public int OrganizationAccountId { get; set; }

    public string Address { get; set; } = null!;

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostalCode { get; set; } = null!;
}
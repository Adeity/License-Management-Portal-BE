namespace LicenseManagementPortal.Model.dto.input;

public class OrganizationAccountOutputDto
{
    public string Name { get; set; } = null!;
    public int? ParentOrganizationId { get; set; }
    public string UserId { get; set; } = null!;
    public string? AccountId { get; set; }
    public int Id { get; set; }
    public int? OrganizationTypeId { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsDeleted { get; set; }
    public List<OrganizationAccountOutputDto> InverseParentOrganization { get; set; } = new List<OrganizationAccountOutputDto>();
    public List<InvoiceOutputDto> Invoices { get; set; } = new List<InvoiceOutputDto>();
    public OrganizationAddressOutputDto? OrganizationAddress { get; set; } = null!;
    public List<OrganizationContactOutputDto> OrganizationContacts { get; set; } = new List<OrganizationContactOutputDto>();
    public List<OrganizationPackageDetailOutputDto> OrganizationPackageDetails { get; set; } = new List<OrganizationPackageDetailOutputDto>();
    public string? OrganizationType { get; set; } = null!;
    public string? ParentOrganization { get; set; }
}
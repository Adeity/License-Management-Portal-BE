namespace LicenseManagementPortal.Model.dto.input;

public class PackageDetailOutputDto
{
    public int Id { get; set; }
    public int? Flags { get; set; }
    public string ProductNumber { get; set; } = null!;
    public bool? Legacy { get; set; }
    public string Prefix { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public bool? LegacyPlus { get; set; }
    public bool? Current { get; set; }
    public string Title { get; set; } = null!;
    public DateTime? UpdateDate { get; set; }
    public int RoleKeyId { get; set; }
    public bool? Engineering { get; set; }
    public int Subscription { get; set; }
    public bool? Advanced { get; set; }
    public bool? Hybrid { get; set; }
    public List<OrganizationPackageDetailOutputDto> OrganizationPackageDetails { get; set; } = new List<OrganizationPackageDetailOutputDto>();
}
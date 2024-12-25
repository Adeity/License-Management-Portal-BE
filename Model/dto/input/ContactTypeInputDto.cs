namespace DP_BE_LicensePortal.Model.dto.input;

public class ContactTypeInputDto
{
    public DateTime UpdateDate { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = null!;
}
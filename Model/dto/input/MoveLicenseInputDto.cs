using System.ComponentModel.DataAnnotations;

namespace LicenseManagementPortal.Model.dto.input;

public class MoveLicenseInputDto
{
    public required int SerialNumberDetailId { get; set; }
    public required int SourceOrganizationAccountId { get; set; }
    public required int TargetOrganizationAccountId { get; set; }
}
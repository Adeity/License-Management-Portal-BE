using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LicenseManagementPortal.Controllers;


[Route("api/organizations/{id}/organization-package-details")]
[ApiController]
[Authorize]
public class OrganizationPackageDetailsController : ControllerBase
{
    private readonly IOrganizationPackageDetailsService _organizationPackageDetailsService;
    public OrganizationPackageDetailsController(
        IOrganizationPackageDetailsService organizationPackageDetailsService
    )
    {
        _organizationPackageDetailsService = organizationPackageDetailsService;
    }


    [HttpPatch("{organizationPackageDetailId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeOrgPackageDetailLicenseCount(int id, int organizationPackageDetailId, [FromBody] ChangePackageDetailQuantityDto dto)
    {

        if (!await _organizationPackageDetailsService.BelongsToOrganizationAccountAsync(organizationPackageDetailId, id))
        {
            return BadRequest($"Organization with ID {id} does not have access to this package detail.");
        }

        var res = await _organizationPackageDetailsService.UpdateSerialNumbersCountAsync(
            organizationPackageDetailId, dto.QuantityOfLicenses);
        return Ok(res);
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateOrganizationPackageDetail(int id, [FromBody] CreateOrgPackageDetailDto createDto)
    {

        await _organizationPackageDetailsService.CreateAsync(createDto.OrganizationAccountId, createDto.PackageDetailsId, createDto.QuantityOfLicenses);

        return NoContent();
    }

    [HttpDelete("{organizationPackageDetailId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteOrganizationPackageDetail(int id, int organizationPackageDetailId)
    {
        if (!await _organizationPackageDetailsService.BelongsToOrganizationAccountAsync(organizationPackageDetailId, id))
        {
            return BadRequest($"Organization with ID {id} does not have access to this package detail.");
        }

        await _organizationPackageDetailsService.DeleteAsync(organizationPackageDetailId);

        return NoContent();
    }

}
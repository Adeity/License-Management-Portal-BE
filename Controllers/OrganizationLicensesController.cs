using Microsoft.AspNetCore.Mvc;
using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Services.Interfaces;
using LicenseManagementPortal.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace LicenseManagementPortal.Controllers;

[Route("api/organizations/{organizationId}/licenses")]
[ApiController]
[Authorize]
public class OrganizationLicensesController : ControllerBase
{

    private readonly ISerialNumberDetailService _serialNumberDetailService;


    public OrganizationLicensesController(ISerialNumberDetailService serialNumberDetailService)
    {
        _serialNumberDetailService = serialNumberDetailService;
    }

    [HttpGet]
    [Authorize(Roles = "Reseller")]
    public async Task<ActionResult<Pagination<LicenseTableDto>>> GetLicensesByOrganization(int organizationId, int pageNumber = 0, int pageSize = 10)
    {
        pageNumber++;
        var licenses = await _serialNumberDetailService.GetOrganizationsLicenses(organizationId, pageNumber, pageSize);
        return Ok(licenses);
    }
}
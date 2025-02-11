using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DP_BE_LicensePortal.Model.dto;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;

namespace DP_BE_LicensePortal.Controllers
{
    [Route("api/licenses")]
    [ApiController]
    public class LicensesController : ControllerBase
    {
        private readonly ISerialNumberDetailService _serialNumberDetailService;

        public LicensesController(ISerialNumberDetailService serialNumberDetailService)
        {
            _serialNumberDetailService = serialNumberDetailService;
        }

        [HttpGet("organizations/{organizationId}")]
        public async Task<ActionResult<IEnumerable<LicenseTableDTO>>> GetLicensesByOrganization(int organizationId)
        {
            var licenses = await _serialNumberDetailService.GetOrganizationsLicenses(organizationId);
            return Ok(licenses);
        }

        // [HttpPost("organizations/{organizationId}")]
        // public async Task<IActionResult> AssignLicense(int organizationId, [FromBody] LicenseInputDto dto)
        // {
        //     var createdLicense = await _licenseService.AssignLicenseAsync(organizationId, dto);
        //     return CreatedAtAction(nameof(GetLicensesByOrganization), new { organizationId }, createdLicense);
        // }
        //
        // [HttpPut("{licenseId}/transfer")]
        // public async Task<IActionResult> TransferLicense(int licenseId, [FromBody] TransferLicenseDto dto)
        // {
        //     var transferredLicense = await _licenseService.TransferLicenseAsync(licenseId, dto.NewOrganizationId);
        //     if (transferredLicense == null) return NotFound();
        //     return Ok(transferredLicense);
        // }
    }
}

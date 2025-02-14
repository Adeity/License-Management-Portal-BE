using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DP_BE_LicensePortal.Model.dto;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;
using ServiceReference1;

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

        [HttpGet("test")]
        public async Task<ActionResult<bool>> test()
        {
            ServiceReference1.ResellerServiceClient client = new ServiceReference1
                .ResellerServiceClient(
                    ResellerServiceClient.EndpointConfiguration.WsHttpBindingSecurityTransport_IResellerService
                    );
            var a = await client.GetSerialNumbersAsync("test account id", "test product number", 2);
            var b = await client.IsValidSerialNumberAsync("bla");
            Console.WriteLine(b);
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            return Ok();
        }
        [HttpGet("organizations/{organizationId}")]
        public async Task<ActionResult<IEnumerable<LicenseTableDTO>>> GetLicensesByOrganization(int organizationId)
        {
            var licenses = await _serialNumberDetailService.GetOrganizationsLicenses(organizationId);
            return Ok(licenses);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateLicense([FromBody] GenerateLicenseInputDto dto)
        {
            await _serialNumberDetailService.GenerateLicense(dto);
            return Created();
            // return CreatedAtAction(nameof(GetLicensesByOrganization), createdLicense);
        }
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

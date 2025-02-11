using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DP_BE_LicensePortal.Model.dto;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.dto.output;

namespace DP_BE_LicensePortal.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationAccountService _organizationService;
        private readonly ISerialNumberDetailService _serialNumberDetailService;

        public OrganizationsController(IOrganizationAccountService organizationService, ISerialNumberDetailService serialNumberDetailService)
        {
            _organizationService = organizationService;
            _serialNumberDetailService = serialNumberDetailService;
        }

        [HttpGet("{organizationId}")]
        public async Task<ActionResult<OrganizationAccountOutputDto>> GetOrganization(int organizationId)
        {
            Console.WriteLine("fuuuck");
            var organization = await _organizationService.GetByIdAsync(organizationId);
            if (organization == null) return NotFound();
            return Ok(organization);
        }
        
        [HttpGet("{organizationId}/licenses")]
        public async Task<ActionResult<LicenseTableDTO>> GetOrganizationLicenses(int organizationId)
        {
            var licenses = await _serialNumberDetailService.GetOrganizationsLicenses(organizationId);
            return Ok(licenses);
        }

        [HttpPut("{organizationId}")]
        public async Task<IActionResult> UpdateOrganization(int organizationId, [FromBody] OrganizationAccountInputDto dto)
        {
            var updatedOrganization = await _organizationService.UpdateAsync(organizationId, dto);
            if (updatedOrganization == null) return NotFound();
            return Ok(updatedOrganization);
        }

        [HttpGet("resellers/{resellerId}")]
        public async Task<ActionResult<IEnumerable<OrganizationAccountOutputDto>>> GetOrganizationsByReseller(int resellerId)
        {
            var organizations = await _organizationService.GetAllByResellerIdAsync(resellerId);
            return Ok(organizations);
        }

        [HttpPost("resellers/{resellerId}")]
        public async Task<IActionResult> CreateOrganization(int resellerId, [FromBody] OrganizationAccountInputDto dto)
        {
            var createdOrganization = await _organizationService.AddAsync(dto);
            return CreatedAtAction(nameof(GetOrganization), new { organizationId = createdOrganization.Id }, createdOrganization);
        }
    }
}

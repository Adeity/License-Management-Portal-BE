using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
// using DP_BE_LicensePortal.Services.Interfaces;
// using DP_BE_LicensePortal.Model.dto.output;

namespace DP_BE_LicensePortal.Controllers
{
    [Route("api/resellers")]
    [ApiController]
    public class ResellersController : ControllerBase
    {
        private readonly IOrganizationAccountService _organizationAccountService;
        private readonly IResellerService _resellerService;

        public ResellersController(IOrganizationAccountService organizationAccountService, IResellerService resellerService)
        {
            _organizationAccountService = organizationAccountService;
            _resellerService = resellerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationAccountOutputDto>>> GetResellers()
        {
            var resellers = await _resellerService.GetAllResellers();
            return Ok(resellers);
        }

        [HttpGet("{resellerId}")]
        public async Task<ActionResult<OrganizationAccountOutputDto>> GetReseller(int resellerId)
        {
            var reseller = await _organizationAccountService.GetByIdAsync(resellerId);
            if (reseller == null) return NotFound();
            return Ok(reseller);
        }
        
        [HttpGet("{resellerId}/organizations")]
        public async Task<ActionResult<OrganizationAccountOutputDto>> GetResellerOrganizations(int resellerId)
        {
            var reseller = await _organizationAccountService.GetAllByResellerIdAsync(resellerId);
            return Ok(reseller);
        }
    }
}

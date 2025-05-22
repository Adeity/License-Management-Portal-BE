using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManagementPortal.Controllers
{
    [Route("api/resellers")]
    [ApiController]
    public class ResellersController : ControllerBase
    {
        private readonly IOrganizationAccountService _organizationAccountService;
        private readonly IResellerService _resellerService;

        public ResellersController(
            IOrganizationAccountService organizationAccountService,
            IResellerService resellerService
            )
        {
            _organizationAccountService = organizationAccountService;
            _resellerService = resellerService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Reseller")]
        public async Task<ActionResult<IEnumerable<OrganizationAccountOutputDto>>> GetResellers()
        {
            var resellers = await _resellerService.GetAllResellers();
            return Ok(resellers);
        }

        [HttpGet("{resellerId}:int")]
        [Authorize(Roles = "Admin,Reseller")]
        public async Task<ActionResult<OrganizationAccountOutputDto>> GetReseller(int resellerId)
        {
            var reseller = await _organizationAccountService.GetByIdAsync(resellerId);
            if (reseller == null) return NotFound();
            return Ok(reseller);
        }
    }
}

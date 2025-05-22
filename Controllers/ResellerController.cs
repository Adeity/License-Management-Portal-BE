using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;
using LicenseManagementPortal.Services;
using LicenseManagementPortal.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace LicenseManagementPortal.Controllers
{
    [Route("api/reseller")]
    [ApiController]
    public class ResellerController : ControllerBase
    {
        private readonly IOrganizationAccountService _organizationAccountService;
        private readonly IResellerService _resellerService;
        private readonly CustomUserManager _userManager;

        public ResellerController(
            IOrganizationAccountService organizationAccountService,
            IResellerService resellerService,
            CustomUserManager userManager
            )
        {
            _organizationAccountService = organizationAccountService;
            _resellerService = resellerService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Reseller")]
        public async Task<ActionResult<OrganizationAccountOutputDto>> GetLoggedResellerInformation()
        {
            var resellerId = await _userManager.GetOrgByPrincipalAsync(User);
            if (resellerId == null)
            {
                return NotFound("Reseller organization account not found for logged user.");
            }

            // Get logged reseller organization by user id
            var res = await _organizationAccountService.GetByIdAsync(resellerId.Value);

            return Ok(res);
        }

        [HttpGet("organizations/all")]
        [Authorize(Roles = "Reseller")]
        public async Task<ActionResult<IEnumerable<OrganizationAccountOutputDto>>> GetResellerOrganizations()
        {
            var resellerId = await _userManager.GetOrgByPrincipalAsync(User);
            if (resellerId == null)
            {
                return NotFound("Reseller organization account not found for logged user.");
            }

            // Get child organizations by reseller id
            var res = await _resellerService.GetChildOrganizations(resellerId.Value);

            return Ok(res);
        }

        [HttpGet("organizations")]
        [Authorize(Roles = "Reseller")]
        public async Task<ActionResult<Pagination<OrganizationAccountOutputDto>>> GetResellerOrganizationsPaginated(int pageNumber = 0, int pageSize = 10)
        {
            var resellerId = await _userManager.GetOrgByPrincipalAsync(User);
            if (resellerId == null)
            {
                return NotFound("Reseller organization account not found for logged user.");
            }

            pageNumber++;
            var userId = _userManager.GetUserId(User);

            // Get child organizations by user id
            var res = await _resellerService.GetChildOrganizationsPaginated(resellerId.Value, pageNumber, pageSize);

            return Ok(res);
        }

        [HttpGet("package-details")]
        [Authorize(Roles = "Reseller")]
        public async Task<ActionResult<IEnumerable<OrganizationPackageDetailOutputDto>>> GetResellerPackageDetails()
        {
            var resellerId = await _userManager.GetOrgByPrincipalAsync(User);
            if (resellerId == null)
            {
                return NotFound("Reseller organization account not found for logged user.");
            }

            // Get child organizations by user id
            var res = await _resellerService.GetResellerPackageDetails(resellerId.Value);

            return Ok(res);
        }
    }
}

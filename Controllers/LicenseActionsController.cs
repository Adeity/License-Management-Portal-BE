using Microsoft.AspNetCore.Mvc;
using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Services.Interfaces;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Services;
using Microsoft.AspNetCore.Authorization;
using IResellerService = LicenseManagementPortal.Services.Interfaces.IResellerService;

namespace LicenseManagementPortal.Controllers
{
    [Route("api/license-actions")]
    [ApiController]
    [Authorize]
    public class LicenseActionsController : ControllerBase
    {
        private readonly ILicenseActionsService _licenseActionsService;
        private readonly IOrganizationAccountService _organizationAccountService;
        private readonly ICustomUserManager _userManager;

        public LicenseActionsController(ISerialNumberDetailService serialNumberDetailService,
            ILicenseActionsService licenseActionsService,
            IOrganizationAccountService organizationAccountService,
            IResellerService resellerService,
            ICustomUserManager userManager
        )
        {
            _licenseActionsService = licenseActionsService;
            _organizationAccountService = organizationAccountService;
            _userManager = userManager;
        }


        [HttpPost("generate")]
        [Authorize(Roles = "Reseller")]
        [ProducesResponseType(typeof(SerialNumberDetailOutputDto), 200)]
        [ProducesResponseType(typeof(ErrorResponseDto), 401)]
        [ProducesResponseType(typeof(ErrorResponseDto), 404)]
        [ProducesResponseType(typeof(ErrorResponseDto), 500)]
        public async Task<ActionResult<SerialNumberDetailOutputDto>> GenerateLicense([FromBody] GenerateLicenseInputDto dto)
        {
            try
            {
                var resellerOrgAccountId = await _userManager.GetOrgByPrincipalAsync(User);
                if (resellerOrgAccountId == null)
                {
                    return NotFound("Reseller organization account not found for logged user.");
                }

                var sourceUnderReseller = await _organizationAccountService.IsChildOrganizationOfReseller(dto.OrganizationAccountId, resellerOrgAccountId.Value);

                if (!sourceUnderReseller)
                    return Unauthorized(new ErrorResponseDto
                    {
                        Message = "Source organization account is not under the logged reseller.",
                        Code = "INVALID_SOURCE_ORGANIZATION"
                    });

                var result = await _licenseActionsService.GenerateLicense(dto, resellerOrgAccountId.Value);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponseDto
                {
                    Message = ex.Message,
                    Code = "NOT_FOUND"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponseDto
                {
                    Message = "An unexpected error occurred while generating the license.",
                    Code = "LICENSE_GENERATION_FAILED",
                    Details = new Dictionary<string, string>
                    {
                        { "error", ex.Message }
                    }
                });
            }
        }

        [HttpPost("move")]
        [Authorize(Roles = "Reseller")]
        [ProducesResponseType(typeof(SerialNumberDetailOutputDto), 200)]
        [ProducesResponseType(typeof(ErrorResponseDto), 401)]
        [ProducesResponseType(typeof(ErrorResponseDto), 404)]
        [ProducesResponseType(typeof(ErrorResponseDto), 500)]
        public async Task<ActionResult<SerialNumberDetailOutputDto>> MoveLicense([FromBody] MoveLicenseInputDto dto)
        {
            try
            {
                var resellerOrgAccountId = await _userManager.GetOrgByPrincipalAsync(User);
                if (resellerOrgAccountId == null)
                {
                    return NotFound("Reseller organization account not found for logged user.");
                }

                var sourceUnderReseller = await _organizationAccountService.IsChildOrganizationOfReseller(dto.SourceOrganizationAccountId, resellerOrgAccountId.Value);
                var targetUnderReseller = await _organizationAccountService.IsChildOrganizationOfReseller(dto.TargetOrganizationAccountId, resellerOrgAccountId.Value);

                if (!sourceUnderReseller)
                    return Unauthorized(new ErrorResponseDto
                    {
                        Message = "Source organization account is not under the logged reseller.",
                        Code = "INVALID_SOURCE_ORGANIZATION"
                    });

                if (!targetUnderReseller)
                    return Unauthorized(new ErrorResponseDto
                    {
                        Message = "Target organization account is not under the logged reseller.",
                        Code = "INVALID_SOURCE_ORGANIZATION"
                    });

                await _licenseActionsService.MoveLicense(dto);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponseDto
                {
                    Message = ex.Message,
                    Code = "NOT_FOUND"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponseDto
                {
                    Message = "An unexpected error occurred while generating the license.",
                    Code = "LICENSE_MOVE_FAILED",
                    Details = new Dictionary<string, string>
                    {
                        { "error", ex.Message }
                    }
                });
            }
        }
    }
}

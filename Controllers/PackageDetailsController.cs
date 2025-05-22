using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManagementPortal.Controllers;

[Route("api/package-details")]
[ApiController]
public class PackageDetailsController : ControllerBase
{
    private readonly IPackageDetailService _packageDetailService;

    public PackageDetailsController(IPackageDetailService packageDetailsService)
    {
        _packageDetailService = packageDetailsService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<PackageDetailOutputDto>>> GetAll()
    {
        var result = await _packageDetailService.GetAllAsync();
        return Ok(result);
    }
}
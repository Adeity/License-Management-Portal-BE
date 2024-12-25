using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DP_BE_LicensePortal.Controllers;

[ApiController]
[Route("api/organizations")]
public class OrganizationAccountController : ControllerBase
{
    private readonly IOrganizationAccountService _organizationAccountService;

    public OrganizationAccountController(IOrganizationAccountService organizationAccountService)
    {
        _organizationAccountService = organizationAccountService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrganizationAccountOutputDto>> GetById(int id)
    {
        var result = await _organizationAccountService.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<OrganizationAccountOutputDto>>> GetAll(int pageIndex = 1, int pageSize = 10)
    {
        var result = await _organizationAccountService.GetAllAsync(pageIndex, pageSize);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OrganizationAccountOutputDto>> Add(OrganizationAccountInputDto dto)
    {
        var result = await _organizationAccountService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<OrganizationAccountOutputDto>> Update(int id, OrganizationAccountInputDto dto)
    {
        var result = await _organizationAccountService.UpdateAsync(id, dto);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _organizationAccountService.DeleteAsync(id);
        return NoContent();
    }
}
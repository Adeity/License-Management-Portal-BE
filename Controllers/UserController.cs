using System.Security.Claims;
using DP_BE_LicensePortal.Model.dto;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DP_BE_LicensePortal.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly UserManager<User> _userManager;

    public UserController(IUserService userService, UserManager<User> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserOutputDto>> GetById(int id)
    {
        var result = await _userService.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<UserOutputDto>>> GetAll(int pageIndex = 1, int pageSize = 10)
    {
        var result = await _userService.GetAllAsync(pageIndex, pageSize);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<UserOutputDto>> Add(UserInputDto dto)
    {
        var result = await _userService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserOutputDto>> Update(int id, UserInputDto dto)
    {
        var result = await _userService.UpdateAsync(id, dto);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<UserOutputDto>> Authenticate([FromBody] LoginDto loginDto)
    {
        var result = await _userService.AuthenticateAsync(loginDto.Email, loginDto.Password);
        if (result == null)
        {
            return Unauthorized();
        }
        return Ok(result);
    }

    [HttpPost("authenticate-windows")]
    [Authorize(AuthenticationSchemes = NegotiateDefaults.AuthenticationScheme)]
    public async Task<ActionResult<UserOutputDto>> AuthenticateWindows()
    {
        var result = await _userService.AuthenticateWindowsAsync();
        if (result == null)
        {
            return Unauthorized();
        }
        return Ok(result);
    }

    [HttpPut("update-password")]
    [Authorize]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await _userService.UpdatePasswordAsync(userId, updatePasswordDto.CurrentPassword, updatePasswordDto.NewPassword);
        return NoContent();
    }
}
using LicenseManagementPortal.Model.database;
using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Services;

namespace LicenseManagementPortal.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

[ApiController]
[Route("api/auth")]
public class AccountController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly CustomUserManager _userManager;

    public AccountController(SignInManager<User> signInManager, CustomUserManager userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, loginDto.RememberMe, false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            var response = new LoginResponseDto
            {
                Email = user.Email,
                Role = role
            };

            return Ok(response);
        }

        return Unauthorized();
    }

    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                var response = new LoginResponseDto
                {
                    Email = user.Email,
                    Role = role
                };

                return Ok(response);
            }
        }

        return Unauthorized();
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { message = "Logged out successfully" });
    }

}

using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Services.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.AspNetCore.Identity;

namespace DP_BE_LicensePortal.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IUserRepository userRepository, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<UserOutputDto> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<Pagination<UserOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        return await _userRepository.GetAllAsync(pageIndex, pageSize);
    }

    public async Task<UserOutputDto> AddAsync(UserInputDto dto)
    {
        var user = new User
        {
            UserName = dto.Email,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            IsSmart = dto.IsSmart
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Failed to create user");
        }

        return user.ToOutputDto();
    }

    public async Task<UserOutputDto> UpdateAsync(int id, UserInputDto dto)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null) return null;

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.UserName = dto.Email;
        user.IsSmart = dto.IsSmart;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            throw new Exception("Failed to update user");
        }

        return user.ToOutputDto();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }
    }

    public async Task<UserOutputDto?> AuthenticateAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, password))
        {
            return null;
        }

        await _signInManager.SignInAsync(user, isPersistent: false);
        return user.ToOutputDto();
    }

    public async Task<UserOutputDto?> AuthenticateWindowsAsync()
    {
        var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
        if (string.IsNullOrEmpty(userName))
        {
            return null;
        }

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return null;
        }

        await _signInManager.SignInAsync(user, isPersistent: false);
        return user.ToOutputDto();
    }

    public async Task UpdatePasswordAsync(int userId, string currentPassword, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        if (!result.Succeeded)
        {
            throw new Exception("Failed to change password");
        }
    }
}

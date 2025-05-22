using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Services.Interfaces;
public interface IUserService
{
    Task<UserOutputDto> GetByIdAsync(int id);
    Task<Pagination<UserOutputDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<UserOutputDto> AddAsync(UserInputDto dto);
    Task<UserOutputDto> UpdateAsync(int id, UserInputDto dto);
    Task DeleteAsync(int id);
    Task<UserOutputDto?> AuthenticateAsync(string email, string password);
    Task<UserOutputDto?> AuthenticateWindowsAsync();
    Task UpdatePasswordAsync(int userId, string currentPassword, string newPassword);
}
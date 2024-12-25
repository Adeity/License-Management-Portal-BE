using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Utilities;

namespace DP_BE_LicensePortal.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserOutputDto> GetByIdAsync(int id);
    Task<Pagination<UserOutputDto>> GetAllAsync(int pageIndex, int pageSize);
    Task<UserOutputDto> AddAsync(UserInputDto dto);
    Task<UserOutputDto> UpdateAsync(int id, UserInputDto dto);
    Task DeleteAsync(int id);
    Task<User?> GetByEmailAsync(string email);

}
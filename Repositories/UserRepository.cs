using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbContext _context;

    public UserRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<UserOutputDto> GetByIdAsync(int id)
    {
        var entity = await _context.Set<User>().FindAsync(id);
        return entity?.ToOutputDto();
    }

    public async Task<Pagination<UserOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        var list = await _context.Set<User>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalItems = await _context.Set<User>().CountAsync();
        var dtoList = list.Select(u => u.ToOutputDto()).ToList();

        return new Pagination<UserOutputDto>(dtoList, totalItems, pageIndex, pageSize);
    }

    public async Task<UserOutputDto> AddAsync(UserInputDto dto)
    {
        var entity = dto.ToEntity();
        _context.Set<User>().Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task<UserOutputDto> UpdateAsync(int id, UserInputDto dto)
    {
        var entity = await _context.Set<User>().FindAsync(id);
        if (entity == null) return null;

        entity.FirstName = dto.FirstName;
        entity.LastName = dto.LastName;
        entity.Email = dto.Email;
        entity.IsSmart = dto.IsSmart;

        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<User>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<User>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
    }
}
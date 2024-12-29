using DP_BE_LicensePortal.Context;
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Repositories;
public class PackageDetailRepository : IPackageDetailRepository
{
    private readonly MyDbContext _context;

    public PackageDetailRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<PackageDetailOutputDto> GetByIdAsync(int id)
    {
        var entity = await _context.Set<PackageDetail>().FindAsync(id);
        return entity?.ToOutputDto();
    }

    public async Task<Pagination<PackageDetailOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        var list = await _context.Set<PackageDetail>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalItems = await _context.Set<PackageDetail>().CountAsync();
        var dtoList = list.Select(pd => pd.ToOutputDto()).ToList();

        return new Pagination<PackageDetailOutputDto>(dtoList, totalItems, pageIndex, pageSize);
    }

    public async Task<PackageDetailOutputDto> AddAsync(PackageDetailInputDto dto)
    {
        var entity = dto.ToEntity();
        _context.Set<PackageDetail>().Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task<PackageDetailOutputDto> UpdateAsync(int id, PackageDetailInputDto dto)
    {
        var entity = await _context.Set<PackageDetail>().FindAsync(id);
        if (entity == null) return null;

        entity.Flags = dto.Flags;
        entity.ProductNumber = dto.ProductNumber;
        entity.Legacy = dto.Legacy;
        entity.Prefix = dto.Prefix;
        entity.ProductName = dto.ProductName;
        entity.LegacyPlus = dto.LegacyPlus;
        entity.Current = dto.Current;
        entity.Title = dto.Title;
        entity.UpdateDate = dto.UpdateDate;
        entity.RoleKeyId = dto.RoleKeyId;
        entity.Engineering = dto.Engineering;
        entity.Subscription = dto.Subscription;
        entity.Advanced = dto.Advanced;
        entity.Hybrid = dto.Hybrid;

        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<PackageDetail>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<PackageDetail>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using DP_BE_LicensePortal.Model.Mappers;
using DP_BE_LicensePortal.Repositories.Interfaces;
using DP_BE_LicensePortal.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Repositories;

public class OrganizationAccountRepository : IOrganizationAccountRepository
{
    private readonly DbContext _context;

    public OrganizationAccountRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<OrganizationAccountOutputDto> GetByIdAsync(int id)
    {
        var entity = await _context.Set<OrganizationAccount>().FindAsync(id);
        return entity?.ToOutputDto();
    }

    public async Task<Pagination<OrganizationAccountOutputDto>> GetAllAsync(int pageIndex, int pageSize)
    {
        var list = await _context.Set<OrganizationAccount>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalItems = await _context.Set<OrganizationAccount>().CountAsync();
        var dtoList = list.Select(oa => oa.ToOutputDto()).ToList();

        return new Pagination<OrganizationAccountOutputDto>(dtoList, totalItems, pageIndex, pageSize);
    }

    public async Task<OrganizationAccountOutputDto> AddAsync(OrganizationAccountInputDto dto)
    {
        var entity = dto.ToEntity();
        _context.Set<OrganizationAccount>().Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task<OrganizationAccountOutputDto> UpdateAsync(int id, OrganizationAccountInputDto dto)
    {
        var entity = await _context.Set<OrganizationAccount>().FindAsync(id);
        if (entity == null) return null;

        entity.Name = dto.Name;
        entity.ParentOrganizationId = dto.ParentOrganizationId;
        entity.UserId = dto.UserId;
        entity.AccountId = dto.AccountId;
        entity.OrganizationTypeId = dto.OrganizationTypeId;
        entity.UpdateDate = dto.UpdateDate;
        entity.IsDeleted = dto.IsDeleted;

        await _context.SaveChangesAsync();
        return entity.ToOutputDto();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<OrganizationAccount>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<OrganizationAccount>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
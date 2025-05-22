using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Repositories;

public class InvoiceTypeRepository : IInvoiceTypeRepository
{
    private readonly IDbContextFactory<MyDbContext> _contextFactory;

    public InvoiceTypeRepository(IDbContextFactory<MyDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<InvoiceType> AddAsync(InvoiceType entity)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            context.Set<InvoiceType>().Add(entity);

            await context.SaveChangesAsync();
            return entity;
        }
    }
}
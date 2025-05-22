using System.Data.Common;
using LicenseManagementPortal.Context;
using LicenseManagementPortal.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace LicenseManagementPortal.Services;

public class MyDbContextProvider : IMyDbContextProvider
{
    public MyDbContext Context { get; set; }

    public MyDbContextProvider(MyDbContext context)
    {
        Context = context;
    }

    public IDbContextTransaction DbTransaction { set; get; }

    public async Task CommitAsync()
    {
        await DbTransaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await DbTransaction.RollbackAsync();
    }

    public async Task BeginTransaction()
    {
        DbTransaction = await Context.Database.BeginTransactionAsync();
    }
}
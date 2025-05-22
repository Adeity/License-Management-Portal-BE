using LicenseManagementPortal.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace LicenseManagementPortal.Services.Interfaces;

public interface IMyDbContextProvider
{
    MyDbContext Context { get; set; }
    IDbContextTransaction DbTransaction { get; set; }
    Task CommitAsync();
    Task RollbackAsync();
    Task BeginTransaction();

}
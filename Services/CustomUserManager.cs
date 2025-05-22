using System.Security.Claims;
using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.database;
using LicenseManagementPortal.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LicenseManagementPortal.Services;

public class CustomUserManager : UserManager<User>, ICustomUserManager
{
    private readonly MyDbContext _context;

    public CustomUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger,
        MyDbContext context
        ) : base(store,
        optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _context = context;
    }

    public async Task<int?> GetOrgByPrincipalAsync(ClaimsPrincipal principal)
    {
        var userId = GetUserId(principal);

        return await _context.Users
            .Where(u => u.Id == userId)
            .Select(u => u.OrganizationContact.OrganizationAccount.Id)
            .FirstOrDefaultAsync();
    }

}
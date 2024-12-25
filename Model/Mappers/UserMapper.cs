using DP_BE_LicensePortal.Model.dto.input;
using DP_BE_LicensePortal.Model.Entities;
using Microsoft.Win32.SafeHandles;

namespace DP_BE_LicensePortal.Model.Mappers;

public static class UserMapper
{
    public static UserOutputDto ToOutputDto(this User entity)
    {
        return new UserOutputDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            IsSmart = entity.IsSmart,
            OrganizationContacts = entity.OrganizationContacts.Select(oc => oc.ToOutputDto()).ToList()
        };
    }

    public static User ToEntity(this UserInputDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            IsSmart = dto.IsSmart,
            WindowsUserName = dto.WindowsUserName
        };
    }
}
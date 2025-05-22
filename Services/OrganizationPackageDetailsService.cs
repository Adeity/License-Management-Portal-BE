using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Model.Mappers;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;

namespace LicenseManagementPortal.Services;

public class OrganizationPackageDetailsService : IOrganizationPackageDetailsService
{
    private readonly IOrganizationPackageDetailsRepository _organizationPackageDetailsRepository;

    public OrganizationPackageDetailsService(
        IOrganizationPackageDetailsRepository organizationPackageDetailsRepository
        )
    {
        _organizationPackageDetailsRepository = organizationPackageDetailsRepository;
    }

    public async Task<OrganizationPackageDetailOutputDto> AddAsync(OrganizationPackageDetailInputDto dto)
    {
        var entity = dto.ToEntity();

        var saved = await _organizationPackageDetailsRepository.AddAsync(entity);
        return saved.ToOutputDto();
    }

    public async Task<OrganizationPackageDetailOutputDto?> GetByOrganizationIdAndPackageDetailsId(int organizationAccountId, int packageDetailsId)
    {
        var res = await _organizationPackageDetailsRepository.GetByOrganizationIdAndPackageDetailsId(organizationAccountId,
            packageDetailsId);
        if (res == null)
        {
            return null;
        }
        return res.ToOutputDto();
    }

    public async Task<OrganizationPackageDetailOutputDto> UpdateAsync(int id, OrganizationPackageDetailInputDto dto)
    {
        var existing = await _organizationPackageDetailsRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"OrganizationPackageDetail with ID {id} not found");

        existing.SerialNumbersCount = dto.SerialNumbersCount;
        existing.UpdateDate = dto.UpdateDate;
        existing.PackageDetailsId = dto.PackageDetailsId;
        existing.OrganizationAccountId = dto.OrganizationAccountId;
        existing.UserID = "System"; // replace with actual user

        var updated = await _organizationPackageDetailsRepository.UpdateAsync(existing);
        return updated.ToOutputDto();
    }

    public async Task<OrganizationPackageDetailOutputDto> UpdateSerialNumbersCountAsync(int id, int newCount)
    {
        var existing = await _organizationPackageDetailsRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"OrganizationPackageDetail with ID {id} not found");

        existing.SerialNumbersCount = newCount;
        existing.UpdateDate = DateTime.UtcNow;

        var updated = await _organizationPackageDetailsRepository.UpdateAsync(existing);
        return updated.ToOutputDto();
    }

    public async Task<OrganizationPackageDetailOutputDto> CreateAsync(int organizationAccountId, int packageDetailsId, int quantityOfLicenses)
    {
        var entity = new OrganizationPackageDetail()
        {
            OrganizationAccountId = organizationAccountId,
            PackageDetailsId = packageDetailsId,
            SerialNumbersCount = quantityOfLicenses,
            UpdateDate = DateTime.UtcNow
        };
        var createdEntity = await _organizationPackageDetailsRepository.AddAsync(entity);
        return createdEntity.ToOutputDto();
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _organizationPackageDetailsRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"OrganizationPackageDetail with ID {id} not found");

        await _organizationPackageDetailsRepository.DeleteAsync(existing);
    }

    public async Task<bool> BelongsToOrganizationAccountAsync(int detailId, int organizationAccountId)
    {
        return await _organizationPackageDetailsRepository.BelongsToOrganizationAccountAsync(detailId, organizationAccountId);
    }

}
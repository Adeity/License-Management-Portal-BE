using Microsoft.AspNetCore.Mvc;
using LicenseManagementPortal.Context;
using LicenseManagementPortal.Model.dto;
using LicenseManagementPortal.Services.Interfaces;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Model.Mappers;
using LicenseManagementPortal.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagementPortal.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationAccountService _organizationService;
        private readonly IOrganizationAccountRepository _organizationAccountRepository;
        private readonly MyDbContext _context;

        public OrganizationsController(IOrganizationAccountService organizationService,
            IOrganizationAccountRepository organizationAccountRepository,
            MyDbContext context
            )
        {
            _organizationService = organizationService;
            _organizationAccountRepository = organizationAccountRepository;
            _context = context;
        }

        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<OrganizationAccountOutputDto>> GetOrganization(int pageNumber = 0, int pageSize = 10)
        {
            pageNumber++;
            var organization = await _organizationService.GetAllPaginatedAsync(pageNumber, pageSize);
            if (organization == null) return NotFound();
            return Ok(organization);
        }


        [HttpGet("{organizationId}")]
        [Authorize(Roles = "Admin,Reseller")]
        public async Task<ActionResult<OrganizationAccountOutputDto>> GetOrganizationByID(int organizationId)
        {
            var organization = await _organizationService.GetByIdAsync(organizationId);
            if (organization == null) return NotFound();
            return Ok(organization);
        }

        [HttpGet("types")]
        [Authorize(Roles = "Admin,Reseller")]
        public async Task<ActionResult<OrganizationTypeOutputDto[]>> GetOrganizationTypes()
        {
            var organizationsTypes = await _context.Set<OrganizationType>()
                .Select(o => new { o.Id, o.Name })
                .ToListAsync();
            if (organizationsTypes.Count == 0) return NotFound();
            return Ok(organizationsTypes);
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateOrganization([FromBody] OrganizationAccountInputDto dto)
        {
            try
            {
                var orgWithNameExists = await _context.OrganizationAccounts.AnyAsync(e => e.Name == dto.Name);
                if (orgWithNameExists) return BadRequest("Organization with name " + dto.Name + " already exists.");
                var organization = await _organizationAccountRepository.AddAsync(dto.ToEntity());
                if (organization == null) return NotFound();
                return Ok(organization.ToOutputDto());
            }
            catch (Exception e)
            {
                return Ok();
            }
        }

        [HttpPut("{organizationId}")]
        public async Task<IActionResult> UpdateOrganization(int organizationId, [FromBody] OrganizationAccountInputDto dto)
        {
            var updatedOrganization = await _organizationService.UpdateAsync(organizationId, dto);
            if (updatedOrganization == null) return NotFound();
            return Ok(updatedOrganization);
        }

        [HttpPatch("{organizationId}/is-deleted")]
        public async Task<IActionResult> RestoreOrganization(int organizationId, [FromBody] IsDeletedInputDto isDeletedInputDto)
        {
            if (isDeletedInputDto.isDeleted)
            {
                await _organizationService.DeleteAsync(organizationId);
            }
            else
            {
                await _organizationAccountRepository.RestoreAsync(organizationId);
            }
            return NoContent();
        }


    }
}

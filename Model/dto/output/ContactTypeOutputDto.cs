﻿using LicenseManagementPortal.Model.dto.input;

namespace LicenseManagementPortal.Model.dto.output;

public class ContactTypeOutputDto
{
    public DateTime UpdateDate { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = null!;
    public List<OrganizationContactOutputDto> OrganizationContacts { get; set; } = new List<OrganizationContactOutputDto>();
}
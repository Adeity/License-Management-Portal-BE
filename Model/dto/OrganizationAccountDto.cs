using System;
using System.Collections.Generic;

namespace LicenseManagementPortal.Entities.Dto;

public class OrganizationAccountDto
{
    public int Id
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
    public string Role
    {
        get;
        set;
    }
    public string OrganizationAccountId
    {
        get;
        set;
    }
    public string Organization
    {
        get;
        set;
    }
    public string PhoneNumber
    {
        get;
        set;
    }
    public string Email
    {
        get;
        set;
    }
    public string Status
    {
        get;
        set;
    }
    public OrganizationAddressDto Address
    {
        get;
        set;
    }
}
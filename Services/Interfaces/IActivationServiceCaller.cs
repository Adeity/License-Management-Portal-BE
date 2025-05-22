namespace LicenseManagementPortal.Services.Interfaces;

public interface IActivationServiceCaller
{
    Task<String> GetLicense(string organizationAccountId, string productNumber);
}
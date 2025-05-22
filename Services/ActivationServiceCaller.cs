using LicenseManagementPortal.Services.Interfaces;
using ServiceReference1;

namespace LicenseManagementPortal.Services;

public class ActivationServiceCaller : IActivationServiceCaller
{
    public async Task<string> GetLicense(string organizationAccountId, string productNumber)
    {
        if (organizationAccountId == null)
        {
            throw new KeyNotFoundException("Organization account entity must have an account id.");
        }

        if (productNumber == null)
        {
            throw new KeyNotFoundException("Product number must not be null to get a license.");
        }

        ResellerServiceClient client = new ResellerServiceClient(
            ResellerServiceClient.EndpointConfiguration.BasicHttpBinding_IResellerService
        );

        var serialNumberResult = await client.GetSerialNumbersAsync(organizationAccountId,
            productNumber,
            1);

        return serialNumberResult[0];
    }
}
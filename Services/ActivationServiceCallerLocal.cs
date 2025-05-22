using System.Text;
using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;
using LicenseManagementPortal.Utilities;

namespace LicenseManagementPortal.Services;

public class ActivationServiceCallerLocal : IActivationServiceCaller
{

    private readonly ISerialNumberRequestLogService _serialNumberRequestLogService;
    private readonly IPackageDetailRepository _packageDetailRepository;
    private readonly ISerialNumberDetailService _serialNumberDetailService;

    public ActivationServiceCallerLocal(ISerialNumberRequestLogService serialNumberRequestLogService,
        ISerialNumberDetailService serialNumberDetailService)
    {
        _serialNumberRequestLogService = serialNumberRequestLogService;
        _serialNumberDetailService = serialNumberDetailService;
    }

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

        // find packageDetailPrefix
        StringBuilder sb = new StringBuilder("");
        for (int i = 0; i < productNumber.Length; i++)
        {
            if (productNumber[i] == '-')
            {
                break;
            }
            sb.Append(productNumber[i]);
        }
        var packageDetailPrefix = sb.ToString();

        // Create the serial number request log
        var serialNumberRequestLogInputDto = new SerialNumberRequestLogInputDto()
        {
            RequestedSn = 1,
            OrderdDate = DateTime.Now,
        };
        var serialNumberRequestLog = await _serialNumberRequestLogService.AddAsync(serialNumberRequestLogInputDto);

        Console.WriteLine("packageDetailPrefix: " + packageDetailPrefix);
        // Create the serial number
        var randomSerialNumber = SerialNumberGenerator.GenerateSerialNumber(packageDetailPrefix);
        Console.WriteLine("Random Serial Number: " + randomSerialNumber);

        var serialNumberDetailInputDto = new SerialNumberDetailInputDto
        {
            AccountId = "fake_accountId",
            SerialNumberRequestLogId = serialNumberRequestLog.Id,
            IsValid = true,
            Prefix = packageDetailPrefix,
            ExpirationDate = DateTime.Now.AddYears(1),
            IsTemp = false,
            ProductNumber = productNumber,
            SerialNumber = randomSerialNumber,
        };

        // Add the serial number into the DB
        await _serialNumberDetailService.AddAsync(serialNumberDetailInputDto);

        return randomSerialNumber;
    }
}
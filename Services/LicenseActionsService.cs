using LicenseManagementPortal.Model.dto.input;
using LicenseManagementPortal.Model.Entities;
using LicenseManagementPortal.Repositories.Interfaces;
using LicenseManagementPortal.Services.Interfaces;
using InvoiceType = LicenseManagementPortal.Model.Enums.InvoiceType;

namespace LicenseManagementPortal.Services;

public class LicenseActionsService : ILicenseActionsService
{
    private readonly IOrganizationAccountService _organizationAccountService;
    private readonly IOrganizationPackageDetailsService _organizationPackageDetailsService;
    private readonly IPackageDetailRepository _packageDetailRepository;
    private readonly IInvoiceService _invoiceService;
    private readonly ISubscriptionItemService _subscriptionItemService;
    private readonly ISerialNumberDetailService _serialNumberDetailService;
    private readonly ISerialNumberDetailRepository _serialNumberDetailRepository;
    private readonly IActivationServiceCaller _activationServiceCaller;
    private readonly IMyDbContextProvider _context;

    public LicenseActionsService(IOrganizationAccountService organizationAccountService,
        IPackageDetailRepository packageDetailRepository,
        IOrganizationPackageDetailsService organizationPackageDetailsService,
        IInvoiceService invoiceService,
        ISubscriptionItemService subscriptionItemService,
        ISerialNumberDetailService serialNumberDetailService,
        ISerialNumberDetailRepository serialNumberDetailRepository,
        IActivationServiceCaller activationServiceCaller,
        IMyDbContextProvider context
    )
    {
        _organizationAccountService = organizationAccountService;
        _organizationPackageDetailsService = organizationPackageDetailsService;
        _packageDetailRepository = packageDetailRepository;
        _invoiceService = invoiceService;
        _subscriptionItemService = subscriptionItemService;
        _serialNumberDetailService = serialNumberDetailService;
        _serialNumberDetailRepository = serialNumberDetailRepository;
        _activationServiceCaller = activationServiceCaller;
        _context = context;
    }

    public async Task MoveLicense(MoveLicenseInputDto dto)
    {
        await _context.BeginTransaction();

        try
        {
            var sourceOrganizationAccount = await _organizationAccountService.GetByIdAsync(dto.SourceOrganizationAccountId);
            if (sourceOrganizationAccount == null)
            {
                throw new KeyNotFoundException($"Organization Account with ID: {dto.SourceOrganizationAccountId} not found.");
            }

            var targetOrganizationAccount = await _organizationAccountService.GetByIdAsync(dto.TargetOrganizationAccountId);
            if (targetOrganizationAccount == null)
            {
                throw new KeyNotFoundException($"Organization Account with ID: {dto.TargetOrganizationAccountId} not found.");
            }

            var serialNumberDetail = await _serialNumberDetailService.GetByIdAsync(dto.SerialNumberDetailId);
            if (serialNumberDetail == null)
            {
                throw new KeyNotFoundException($"License with ID: {dto.SerialNumberDetailId} not found.");
            }

            var isAssignedToSource = await _serialNumberDetailRepository.OrganizationHasSerialNumberDetailAsync(dto.SourceOrganizationAccountId, dto.SerialNumberDetailId);
            if (!isAssignedToSource)
            {
                throw new KeyNotFoundException($"Cannot move license with ID: {dto.SerialNumberDetailId} because it is not assigned to the source organization account with ID: {dto.SourceOrganizationAccountId}.");
            }

            // create the invoice
            var invoiceMovedAwayInput = new InvoiceInputDto()
            {
                InvoiceTypeId = InvoiceType.Moved_Away,
                OrganizationAccountId = sourceOrganizationAccount.Id,
                UpdateDate = DateTime.UtcNow
            };
            var createdInvoiceMovedAway = await _invoiceService.AddAsync(invoiceMovedAwayInput);

            // create the subscription item
            var subscriptionItemMovedAwayInput = new SubscriptionItemInputDto()
            {
                InvoiceId = createdInvoiceMovedAway.Id,
                SerialNumberDetailsId = serialNumberDetail.Id,
                EMailSentCount = 0,
                UpdateDate = DateTime.UtcNow,
            };

            await _subscriptionItemService.AddAsync(subscriptionItemMovedAwayInput);


            var invoiceMoveToNew = new InvoiceInputDto()
            {
                InvoiceTypeId = InvoiceType.Move_License,
                OrganizationAccountId = targetOrganizationAccount.Id,
                UpdateDate = DateTime.UtcNow
            };
            var createdInvoice = await _invoiceService.AddAsync(invoiceMoveToNew);

            // create the subscription item
            var subscriptionItemMoveToNewInput = new SubscriptionItemInputDto()
            {
                InvoiceId = createdInvoice.Id,
                SerialNumberDetailsId = serialNumberDetail.Id,
                EMailSentCount = 0,
                UpdateDate = DateTime.UtcNow,
            };

            await _subscriptionItemService.AddAsync(subscriptionItemMoveToNewInput);

            await _context.CommitAsync();
        }
        catch
        {
            await _context.RollbackAsync();
            throw;
        }
    }

    public async Task<SerialNumberDetailOutputDto> GenerateLicense(GenerateLicenseInputDto dto, int resellerOrgAccountId)
    {
        await _context.BeginTransaction();
        try
        {

            PackageDetail? packageDetail = await _packageDetailRepository.GetByIdAsync(dto.PackageDetailsId);
            if (packageDetail == null)
            {
                throw new KeyNotFoundException($"Package Detail with ID: {dto.PackageDetailsId} not found.");
            }

            var targetOrganizationAccount = await _organizationAccountService.GetByIdAsync(dto.OrganizationAccountId);
            if (targetOrganizationAccount == null)
            {
                throw new KeyNotFoundException($"Organization Account with ID: {dto.OrganizationAccountId} not found.");
            }

            var orgPackageDetails = await _organizationPackageDetailsService.GetByOrganizationIdAndPackageDetailsId(
                resellerOrgAccountId, dto.PackageDetailsId);
            if (orgPackageDetails == null)
            {
                throw new KeyNotFoundException($"Organization Package Detail with ID: {dto.PackageDetailsId} not found.");
            }

            // Call the get license service
            var serialNumber = await _activationServiceCaller.GetLicense(targetOrganizationAccount.Id.ToString(), packageDetail.ProductNumber);

            if (serialNumber == "ERROR")
            {
                throw new Exception(
                    "The WCF service call resulted in ERROR while generating license with parameters: " +
                    targetOrganizationAccount.AccountId + " and " + packageDetail.ProductName);
            }

            // Create the invoice
            var invoiceInputDto = new InvoiceInputDto()
            {
                InvoiceTypeId = InvoiceType.Create_New_Licenses,
                OrganizationAccountId = targetOrganizationAccount.Id
            };

            var createdInvoice = await _invoiceService.AddAsync(invoiceInputDto);

            // create the subscription item
            var idSerialNumberDetail = await _serialNumberDetailService.GetIdBySerialNumber(serialNumber);
            var subscriptionItemInputDto = new SubscriptionItemInputDto()
            {
                InvoiceId = createdInvoice.Id,
                SerialNumberDetailsId = idSerialNumberDetail,
                EMailSentCount = 0,
            };
            await _subscriptionItemService.AddAsync(subscriptionItemInputDto);

            await _organizationAccountService.UpdateOrgPackageDetailCountAsync(
                resellerOrgAccountId, orgPackageDetails.Id, orgPackageDetails.SerialNumbersCount - 1);


            await _context.CommitAsync();

            return new SerialNumberDetailOutputDto() { SerialNumber = serialNumber };
        }
        catch
        {
            await _context.RollbackAsync();
            throw;
        }
    }
}
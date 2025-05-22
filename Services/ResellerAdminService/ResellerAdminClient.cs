using System.ServiceModel.Description;

namespace LicenseManagementPortal.Services.ResellerAdminService;

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

[GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IResellerAdminChannel : IResellerAdmin, IClientChannel
{
}

[DebuggerStepThroughAttribute()]
[GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public class ResellerAdminClient : ClientBase<IResellerAdmin>, IResellerAdmin
{

    public ResellerAdminClient()
    {
    }

    public ResellerAdminClient(ServiceEndpoint endpointConfigurationName) :
    base(endpointConfigurationName)
    {
    }

    public ResellerAdminClient(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress) :
        base(binding, remoteAddress)
    {
    }

    public StatusChangeResult ChangeActivationStatus(string serialNumber, ActivationStatus newStatus, string reason, string userID)
    {
        try
        {
            return base.Channel.ChangeActivationStatus(serialNumber, newStatus, reason, userID);
        }
        catch (Exception ex)
        {
            var test = ex.InnerException.ToString();
            return new StatusChangeResult { };
        }
    }
    public RenewResult RenewSerialNumber(RenewRequest request, string userId)
    {
        try
        {
            return base.Channel.RenewSerialNumber(request, userId);

        }
        catch (Exception ex)
        {
            var test = ex.InnerException.ToString();
            return new RenewResult { };
        }
    }
    /// <summary>
    /// Generate Serial Number with fixed (1 Year Expiration Date)
    /// </summary>
    /// <param name="accountID"></param>
    /// <param name="productNumber"></param>
    /// <param name="requestedSerialNum"></param>
    /// <param name="userID"></param>
    /// <returns></returns>
    public string[] GetSerialNumbers(string accountID, string productNumber, int requestedSerialNum, string userID)
    {
        return base.Channel.GetSerialNumbers(accountID, productNumber, requestedSerialNum, userID);

    }

    /// <summary>
    /// Generate Serial Number with overriding the default 1 year Expiration Date
    /// </summary>
    /// <param name="accountID"></param>
    /// <param name="productNumber"></param>
    /// <param name="requestedSerialNum"></param>
    /// <param name="userID"></param>
    /// <param name="expirationDate"></param>
    /// <returns></returns>
    public string[] GetSerialNumbersWithExpirationDate(string accountID, string productNumber, int requestedSerialNum, string userID, System.DateTime expirationDate)
    {
        return base.Channel.GetSerialNumbersWithExpirationDate(accountID, productNumber, requestedSerialNum, userID, expirationDate);
    }

    /// <summary>
    /// Basic Method to Test Comunication with the WCF Service
    /// </summary>
    /// <param name="serialNumber"></param>
    /// <returns></returns>
    public string IsValidSerialNumber(string serialNumber)
    {

        return base.Channel.IsValidSerialNumber(serialNumber);
    }
}

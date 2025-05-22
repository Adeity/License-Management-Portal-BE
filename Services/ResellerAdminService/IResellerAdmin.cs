namespace LicenseManagementPortal.Services.ResellerAdminService;

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IResellerAdmin")]
public interface IResellerAdmin
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IResellerAdmin/GetSerialNumbers", ReplyAction = "http://tempuri.org/IResellerAdmin/GetSerialNumbersResponse")]
    string[] GetSerialNumbers(string accountID, string productNumber, int requestedSerialNum, string userID);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IResellerAdmin/GetSerialNumbersWithExpirationDate", ReplyAction = "http://tempuri.org/IResellerAdmin/GetSerialNumbersWithExpirationDateResponse")]
    string[] GetSerialNumbersWithExpirationDate(string accountID, string productNumber, int requestedSerialNum, string userID, System.DateTime expirationDate);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IResellerAdmin/IsValidSerialNumber", ReplyAction = "http://tempuri.org/IResellerAdmin/IsValidSerialNumberResponse")]
    string IsValidSerialNumber(string serialNumber);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IResellerAdmin/ChangeActivationStatus", ReplyAction = "http://tempuri.org/IResellerAdmin/ChangeActivationStatusResponse")]
    StatusChangeResult ChangeActivationStatus(string serialNumber, ActivationStatus newStatus, string reason, string userID);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IResellerAdmin/RenewSerialNumber", ReplyAction = "http://tempuri.org/IResellerAdmin/RenewSerialNumberResponse")]
    RenewResult RenewSerialNumber(RenewRequest request, string userId);
}
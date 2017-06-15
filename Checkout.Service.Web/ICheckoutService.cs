using System.ServiceModel;

namespace Checkout.Service.Web
{
    [ServiceContract]
    public interface ICheckoutService
    {
        [OperationContract]
        CheckoutResponse Scan(string item);

        [OperationContract]
        CheckoutResponse CancelScan(string item);

        [OperationContract]
        decimal TotalPrice();
    }
}
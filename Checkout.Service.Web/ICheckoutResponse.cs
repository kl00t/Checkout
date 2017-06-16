namespace Checkout.Service.Web
{
    public interface ICheckoutResponse
    {
        bool IsScanSuccessful { get; set; }

        string Error { get; set; }
    }
}
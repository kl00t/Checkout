namespace Checkout.Service.Web
{
    using Ninject.Extensions.Wcf;

    /// <summary>
    /// Custom service host factory.
    /// </summary>
    /// <seealso cref="Ninject.Extensions.Wcf.NinjectServiceHostFactory" />
    public class CustomServiceHostFactory : NinjectServiceHostFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomServiceHostFactory"/> class.
        /// </summary>
        public CustomServiceHostFactory()
        {
            // inject anything here
        }
    }
}
namespace Checkout.Service.Web
{
    using Core;
    using Data;
    using Domain.Interfaces;
    using Domain.Models;
    using Ninject.Modules;

    /// <summary>
    /// Ninject Service module.
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule" />
    public class ServiceModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<ICheckoutService>().To<CheckoutService>();
            Bind<ICheckout>().To<Checkout>();
            Bind<IProduct>().To<Product>();
            Bind<ICarrierBag>().To<CarrierBag>();
            //Bind<IProductRepository>().To<ProductRepository>();
            Bind<IProductRepository>().To<MockProductRepository>();
        }
    }
}
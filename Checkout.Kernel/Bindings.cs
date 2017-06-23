namespace Checkout.Kernel
{
    using Core;
    using Core.Logging;
    using Data;
    using Domain.Interfaces;
    using Domain.Models;
    using Ninject.Modules;

    public class Bindings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<ILogger>().To<Logger>();
            Bind<IBasket>().To<Basket>();
            Bind<ICheckout>().To<Checkout>();
            Bind<IProduct>().To<Product>();
            Bind<ICarrierBag>().To<CarrierBag>();
            Bind<IProductRepository>().To<MockProductRepository>();
            ////Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}
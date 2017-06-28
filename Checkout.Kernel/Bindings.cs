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

			Bind<ICheckout>().To<Checkout>();
			Bind<ICarrierBag>().To<CarrierBag>();

			Bind<IBasket>().To<Basket>();
			//Bind<IBasketRepository>().To<BasketRepository>();
			Bind<IBasketRepository>().To<MockBasketRepository>();

			Bind<IProduct>().To<Product>();
            Bind<IProductRepository>().ToConstant(new MockProductRepository());
            ////Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}
namespace Checkout.Service.Web
{
    using Core;
    using Data;
    using Ninject.Modules;

    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICheckoutService>().To<CheckoutService>();
            Bind<ICheckout>().To<Checkout>();
            Bind<IProduct>().To<Product>();
            Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}
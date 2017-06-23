namespace Checkout.Service.Web
{
    using System;
    using Ninject;
    using Ninject.Web.Common;

    public class Global : NinjectHttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected override IKernel CreateKernel()
        {
            ////IKernel kernel = new StandardKernel();
            ////try
            ////{
            ////    kernel.Load("*.Kernel.dll");
            ////    return kernel;
            ////}
            ////catch
            ////{
            ////    kernel.Dispose();
            ////    throw;
            ////}

            return new StandardKernel(new Kernel.Bindings());

            ////return new StandardKernel(new ServiceModule());
        }
    }
}
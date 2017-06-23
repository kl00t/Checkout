namespace Checkout.Core.Tests
{
    using System;
    using Ninject;
    using NUnit.Framework;

    [SetUpFixture]
    public class Startup
    {
        /// <summary>
        /// Gets or sets the kernel.
        /// </summary>
        public static IKernel Kernel { get; set; }

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Kernel = new StandardKernel();
            Kernel.Load("*.kernel.dll");
            Console.WriteLine("Completed Startup...");
        }
    }
}
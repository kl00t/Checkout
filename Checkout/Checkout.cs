namespace Checkout.Core
{
    using Data;

    /// <summary>
    /// Checkout core class.
    /// </summary>
    public class Checkout : ICheckout
    {
        /// <summary>
        /// The product repository
        /// </summary>
        private IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        public Checkout()
        {
            _productRepository = new ProductRepository();
        }

        /// <summary>
        /// Scans the specified item.
        /// </summary>
        /// <param name="item">The name of scanned item.</param>
        public void Scan(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                TotalPrice += 0;
            }
            else
            {
                TotalPrice += _productRepository.GetProductUnitPrice(item);
            }
        }

        /// <summary>
        /// Gets the total price.
        /// </summary>
        /// <returns>
        /// Returns the total price as a whole number.
        /// </returns>
        public int GetTotalPrice()
        {
            return TotalPrice;
        }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public int TotalPrice { get; set; }
    }
}
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
        private readonly IProductRepository _productRepository;

		/// <summary>
		/// The basket of items.
		/// </summary>
		private readonly IBasket _basket;

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        public Checkout(IProductRepository productRepository, IBasket basket)
        {
            _productRepository = productRepository;
			_basket = basket;
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
				var product = _productRepository.GetProductBySkuCode(item);
				_basket.Products.Add(product);
				TotalPrice += product.UnitPrice;
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
			var subTotal = 0;
			foreach(var item in _basket.Products)
			{
				subTotal += item.UnitPrice;
			}

			TotalPrice = subTotal;
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
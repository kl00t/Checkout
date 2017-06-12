namespace Checkout.Core
{
    using Data;
	using System.Collections.Generic;
    using System.Linq;

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
		private readonly List<Product> _basket;

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        public Checkout(IProductRepository productRepository)
        {
            _productRepository = productRepository;
			_basket = new List<Product>();
        }

        /// <summary>
        /// Scans the specified item.
        /// </summary>
        /// <param name="item">The name of scanned item.</param>
        public void Scan(string item)
        {
			if (!string.IsNullOrEmpty(item))
			{
				var product = _productRepository.GetProductBySkuCode(item);
				_basket.Add(product);
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

            // 1) Group the items in basket by SKUcode.
            var groupedProductList = _basket
                .GroupBy(u => u.Sku)
                .Select(grp => grp.ToList())
                .ToList();

            foreach (var productGroup in groupedProductList)
            {
                // 2) if the item special offer is available
                if (productGroup.Any(x => x.SpecialOffer.IsAvailable))
                {
                    var quantity = productGroup.First().SpecialOffer.Quantity;
                    var discount = productGroup.First().SpecialOffer.Discount;

                    // 3) then Group them by the quantity
                    // 4) apply the discount at the end.

                    // total up the items.
                    foreach (var item in productGroup)
                    {
                        subTotal += item.UnitPrice;
                    }
                }
                else
                {
                    // no special offer on items so just total up the items.
                    foreach (var item in productGroup)
                    {
                        subTotal += item.UnitPrice;
                    }
                }
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
namespace Checkout.Core
{
    using Data;
	using System.Collections.Generic;
    using System.Linq;
    using Extensions;

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
            if (string.IsNullOrEmpty(item))
            {
                // check condition and return early.
                return;
            }

            _basket.Add(_productRepository.GetProductBySkuCode(item));
        }

        /// <summary>
        /// Cancels the scanned item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void CancelScan(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                // check condition and return early.
                return;
            }

            _basket.Remove(_productRepository.GetProductBySkuCode(item));
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
            var totalDiscount = 0;

            // group the items in basket by SKUcode.
            var groupedProductList = _basket.GroupBy(u => u.Sku).Select(grp => grp.ToList()).ToList();

            foreach (var productGroup in groupedProductList)
            {
                // if the item special offer is available
                if (productGroup.Any(x => x.SpecialOffer.IsAvailable))
                {
                    var quantity = productGroup.First().SpecialOffer.Quantity;
                    var discount = productGroup.First().SpecialOffer.Discount;

                    //  then Group them by the quantity
                    foreach (var itemsToCalculate in productGroup.SplitItems(quantity))
                    {
                        // if items matches the quantity for discount then apply discount.
                        if (itemsToCalculate.Count() == quantity)
                        {
                            // apply the discount
                            totalDiscount += discount;
                        }
                    }
                }

                // total up the items.
                subTotal += productGroup.Sum(item => item.UnitPrice);
            }

            TotalPrice = subTotal - totalDiscount;
			return TotalPrice;
        }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public int TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the total discount.
        /// </summary>
        /// <value>
        /// The total discount.
        /// </value>
        public int Discount { get; set; }


        public string GetTotalDiscounts()
        {
            throw new System.NotImplementedException();
        }
    }
}
namespace Checkout.Core
{
    using Data;
	using System.Collections.Generic;
    using System.Linq;
    using Domain.Interfaces;
    using Domain.Models;
    using Extensions;
    using Resources;

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
		/// The carrier bag instance.
		/// </summary>
		private readonly ICarrierBag _carrierBag;

		/// <summary>
		/// The basket of items.
		/// </summary>
		private readonly List<Product> _basket;

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout" /> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="carrierBag">The carrier bag.</param>
        public Checkout(IProductRepository productRepository, ICarrierBag carrierBag)
        {
            _productRepository = productRepository;
			_carrierBag = carrierBag;
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
        public decimal GetTotalPrice()
        {
            CalculatePrice();
			TotalBagCharge = _carrierBag.CalculateBagCharge(_basket.Count);
            TotalPrice = (SubTotal + TotalBagCharge) - TotalDiscount;
            return TotalPrice;
        }

        /// <summary>
        /// Gets the total discounts.
        /// </summary>
        /// <returns>
        /// Returns the total discounts message.
        /// </returns>
        public string GetTotalDiscounts()
        {
            return TotalDiscount == 0 ? Discounts.NoDiscountsApplied : string.Format(Discounts.DiscountsApplied, TotalDiscount.ToString("#.##"));
        }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the total discount.
        /// </summary>
        /// <value>
        /// The total discount.
        /// </value>
        public decimal TotalDiscount { get; set; }

		/// <summary>
		/// Gets or sets the total bag charges.
		/// </summary>
		/// <value>
		/// The total bag charges.
		/// </value>
		public decimal TotalBagCharge { get; set; }

        /// <summary>
        /// Gets or sets the sub total.
        /// </summary>
        /// <value>
        /// The sub total.
        /// </value>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Method that calculates the price.
        /// </summary>
        private void CalculatePrice()
        {
            var subTotal = 0.0m;
            var totalDiscount = 0.0m;

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
                    totalDiscount += productGroup.SplitItems(quantity)
                        .Where(itemsToCalculate => itemsToCalculate.Count() == quantity)
                        .Sum(itemsToCalculate => discount);
                }

                // total up the items.
                subTotal += productGroup.Sum(item => item.UnitPrice);
            }

            TotalDiscount = totalDiscount;
            SubTotal = subTotal;
        }
    }
}
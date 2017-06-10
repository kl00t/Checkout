using System.Collections.Generic;
using Checkout.Data;

namespace Checkout.Core
{
	public class Basket : IBasket
	{
		public Basket()
		{
			Products = new List<Product>();
		}

		public IList<Product> Products { get; set; }


	}
}

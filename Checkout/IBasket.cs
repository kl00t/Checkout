using Checkout.Data;
using System.Collections.Generic;

namespace Checkout.Core
{
	public interface IBasket
	{
		IList<Product> Products { get; set; }
	}
}

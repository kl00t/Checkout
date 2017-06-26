namespace Checkout.Data
{
    using System;
    using System.Collections.Generic;
    using Domain.Models;

    /// <summary>
    /// Fake data class.
    /// </summary>
    public static class FakeData
    {
        /// <summary>
        /// Fakes the products.
        /// </summary>
        /// <returns>Returns fake products.</returns>
        public static List<Product> FakeProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.Parse("B194D57D-C258-4AA2-B01B-D71F898C1DD3"),
                    Sku = "A",
                    UnitPrice = 50m,
                    Description = "Pineapple",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = true,
                        Quantity = 3,
                        Discount = 20
                    }
                },
                new Product
                {
                    Id = Guid.Parse("5E6EA04C-E2D2-4CE9-B88B-C4F3FA1D3BEC"),
                    Sku = "B",
                    UnitPrice = 30m,
                    Description = "Mango",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = true,
                        Quantity = 2,
                        Discount = 15
                    }
                },
                new Product
                {
                    Id = Guid.Parse("52B90EEF-60E2-40B4-8CCC-1EBBA4780EF8"),
                    Sku = "C",
                    UnitPrice = 20m,
                    Description = "Kiwi",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = false
                    }
                },
                new Product
                {
                    Id = Guid.Parse("204712C0-BE5E-4ABF-A08B-2B3BCA087BC4"),
                    Sku = "D",
                    UnitPrice = 15m,
                    Description = "Melon",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = false
                    }
                },
                new Product
                {
                    Id = Guid.Parse("021273CF-8207-4EAD-9F05-2BCEF31B7BA7"),
                    Sku = "E",
                    UnitPrice = 9.99m,
                    Description = "Banana",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = true,
                        Quantity = 3,
                        Discount = 9.99m
                    }
                }
            };

            return products;
        }

        /// <summary>
        /// Fakes the baskets.
        /// </summary>
        /// <returns>Returns fake baskets.</returns>
        public static Dictionary<Guid, List<Product>> FakeBaskets()
        {
            var baskets = new Dictionary<Guid, List<Product>>
            {
                {
                    Guid.Parse("E2BE4369-2CDE-424D-9E84-39E8C6472B6C"),
                    new List<Product>
                    {
                        new Product
                        {
                            Id = Guid.Parse("B194D57D-C258-4AA2-B01B-D71F898C1DD3")
                        }
                    }
                },
                {
                    Guid.Parse("58B03959-33A0-40EF-8EE9-57C0685D97B4"),
                    new List<Product>
                    {
                        new Product
                        {
                            Id = Guid.Parse("B194D57D-C258-4AA2-B01B-D71F898C1DD3")
                        },
                        new Product
                        {
                            Id = Guid.Parse("5E6EA04C-E2D2-4CE9-B88B-C4F3FA1D3BEC")
                        }
                    }
                },
                {
                    Guid.Parse("8CB1BD63-686C-479F-B4FB-A7239619A016"),
                    new List<Product>
                    {
                        new Product
                        {
                            Id = Guid.Parse("B194D57D-C258-4AA2-B01B-D71F898C1DD3")
                        },
                        new Product
                        {
                            Id = Guid.Parse("B194D57D-C258-4AA2-B01B-D71F898C1DD3")
                        },
                        new Product
                        {
                            Id = Guid.Parse("B194D57D-C258-4AA2-B01B-D71F898C1DD3")
                        }
                    }
                }
            };

            return baskets;
        } 
    }
}
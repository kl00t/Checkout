namespace Checkout.Data
{
    using System.Data.Entity;
    using Domain.Models;

    public partial class CheckoutDbContext : DbContext
    {
        public CheckoutDbContext()
            : base("name=CheckoutDbContext")
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<SpecialOffer> SpecialOffers { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
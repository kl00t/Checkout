namespace Checkout.Data
{
    using System.Data.Entity;
    using Domain.Models;

    public class CheckoutContext : DbContext
    {
        public CheckoutContext() : base("name=CheckoutDb")
        {
            Database.SetInitializer<CheckoutContext>(new CreateDatabaseIfNotExists<CheckoutContext>());
            //Database.SetInitializer<CheckoutContext>(new DropCreateDatabaseIfModelChanges<CheckoutContext>());
            //Database.SetInitializer<CheckoutContext>(new DropCreateDatabaseAlways<CheckoutContext>());
            //Database.SetInitializer<CheckoutContext>(new CheckoutDbInitializer());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Basket> Basket { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductEntityConfiguration());
            modelBuilder.Configurations.Add(new SpecialOfferEntityConfiguration());
            modelBuilder.Configurations.Add(new BasketEntityConfiguration());
        }
    }
}
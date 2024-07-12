using Microsoft.EntityFrameworkCore;

namespace Ef_testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext()) 
            {
                var purchase = new Purchase()
                {
                    Id = 1,
                    Product = "Hat",
                    Price = 36.5m
                };
                context.Add(purchase);
            
                context.SaveChanges();
            
            
                //

                var allPurchases = context.Purchases.ToList();
            
            }
        }

        public class MyDbContext : DbContext
        {
            public  DbSet<Purchase> Purchases { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("MyDb");
            }

        }

        public class Purchase
        {
            public int Id { get; set; }
            public string? Product { get; set; }
            public decimal Price { get; set; }
        }
    }
}

using GeekShopping.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Context
{
    public class MYSQLContext : DbContext
    {
        public MYSQLContext() { }
        public MYSQLContext(DbContextOptions<MYSQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "pepsi",
                Price = new decimal(5.5),
                Description = "pepsi",
                ImageUrl = "aa",
                CategoryName = "refri"
            });
        }
    }
}

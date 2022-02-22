using GeekShopping.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Context
{
    public class MYSQLContext : DbContext
    {
        public MYSQLContext() { }
        public MYSQLContext(DbContextOptions<MYSQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}

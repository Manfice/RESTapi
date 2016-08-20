using System.Data.Entity;
using spWeb.Models.Entitys;

namespace spWeb.Models.DbConnect
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext():base("ssDB")
        {
            Database.SetInitializer<ProductDbContext>(new ProductDbInitilizer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
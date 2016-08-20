using System.Collections.Generic;
using System.Threading.Tasks;
using spWeb.Models.DbConnect;
using spWeb.Models.Entitys;

namespace spWeb.Models.Abstract
{
    public class ProductRepository : IRepository
    {
        private readonly ProductDbContext _context = new ProductDbContext();
        public IEnumerable<Order> Orders => _context.Orders;


        public IEnumerable<Product> Products => _context.Products;


        public async Task<Order> DeleteOrderAsync(int orderId)
        {
            var dbOrder = _context.Orders.Find(orderId);
            if (dbOrder!=null)
            {
                _context.Orders.Remove(dbOrder);
            }
            await _context.SaveChangesAsync();
            return dbOrder;
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var dbProduct = _context.Products.Find(productId);
            if (dbProduct!=null)
            {
                _context.Products.Remove(dbProduct);
            }
            await _context.SaveChangesAsync();
            return dbProduct;
        }

        public async Task<int> SaveOrderAsync(Order order)
        {
            if (order.Id==0)
            {
                _context.Orders.Add(order);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveProductAsync(Product product)
        {
            if (product.Id==0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var dbProduct = _context.Products.Find(product.Id);
                dbProduct.Title = product.Title;
                dbProduct.Descr = product.Descr;
                dbProduct.Price = product.Price;
                dbProduct.Category = product.Category;
            }
            return await _context.SaveChangesAsync();
        }
    }
}
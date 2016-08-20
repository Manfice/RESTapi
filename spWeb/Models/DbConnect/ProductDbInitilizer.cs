using System.Collections.Generic;
using System.Data.Entity;
using spWeb.Models.Entitys;

namespace spWeb.Models.DbConnect
{
    public class ProductDbInitilizer:DropCreateDatabaseAlways<ProductDbContext>
    {
        protected override void Seed(ProductDbContext context)
        {
            new List<Product>
            {
                new Product { Title = "Витая пара", Descr = "Кабель витая пара", Price = 2300m, Category = "Кабель"},
                new Product { Title = "Коннектор", Descr = "Коннектор 8р8р", Price = 3m, Category = "Аксессуары"},
                new Product { Title = "Обжимка", Descr = "Обжимной инструмент для витой пары", Price = 1250m, Category = "Инструмент"},
                new Product { Title = "УЗК", Descr = "Устройство для протяжки кабеля", Price = 650m, Category = "Инструмент"}
            }.ForEach(p=>context.Products.Add(p));
            context.SaveChanges();

            new List<Order>
            {
                new Order { Customer = "Вася", TotalCost = 20m, OrderLines = new List<OrderLine>
                {
                    new OrderLine {ProductId = 1, Count = 10},
                    new OrderLine {ProductId = 2, Count = 100}
                } },
                new Order { Customer = "Коля", TotalCost = 30m, OrderLines = new List<OrderLine>
                {
                    new OrderLine {ProductId = 1, Count = 5},
                    new OrderLine {ProductId = 4, Count = 3}
                } }
            }.ForEach(o=>context.Orders.Add(o));
        }
    }
}
using System.Collections.Generic;

namespace spWeb.Models.Entitys
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public decimal TotalCost { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }   
    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
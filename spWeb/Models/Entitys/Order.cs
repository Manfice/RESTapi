using System.Collections.Generic;

namespace spWeb.Models.Entitys
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public decimal TotalCost { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }   
    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
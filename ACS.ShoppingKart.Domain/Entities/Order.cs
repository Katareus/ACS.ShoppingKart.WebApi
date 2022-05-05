using System;
using System.Collections.Generic;

namespace ACS.ShoppingKart.Domain.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public List<OrderProduct> OrderDetails { get; set; }
    }
}

using ACS.ShoppingKart.Domain.Enums;

namespace ACS.ShoppingKart.Domain.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public ProductType Type { get; set; }
        public decimal Price { get; set; }
    }
}

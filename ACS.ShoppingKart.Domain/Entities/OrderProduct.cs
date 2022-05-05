namespace ACS.ShoppingKart.Domain.Entities
{
    public class OrderProduct
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}

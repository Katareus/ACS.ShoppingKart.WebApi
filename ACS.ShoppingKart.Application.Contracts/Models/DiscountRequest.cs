namespace ACS.ShoppingKart.Application.Contracts.Models
{
    public class DiscountRequest
    {
        public string Promocode { get; set; }
        public string OrderId { get; set; }
    }
}

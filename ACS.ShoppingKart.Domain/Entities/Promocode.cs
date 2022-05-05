using ACS.ShoppingKart.Domain.Enums;

namespace ACS.ShoppingKart.Domain.Entities
{
    public  class Promocode
    {
        public string Id { get; set; }
        public PromocodeType Type { get; set; }
        public bool IsPercentage { get; set; }
        public int DiscountKey { get; set; }
        public decimal DiscountValue { get; set; }
    }
}

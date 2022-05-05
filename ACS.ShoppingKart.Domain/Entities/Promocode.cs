namespace ACS.ShoppingKart.Domain.Entities
{
    public  class Promocode
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public bool IsPercentage { get; set; }
        public string Value { get; set; }
    }
}

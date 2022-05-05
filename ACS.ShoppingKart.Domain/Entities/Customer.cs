using ACS.ShoppingKart.Domain.Enums;

namespace ACS.ShoppingKart.Domain.Entities
{
    public class Customer
    {
        public string Id { get; set; }
        public CustomerType Type { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZIP { get; set; }
        public string Email { get; set; }
    }
}

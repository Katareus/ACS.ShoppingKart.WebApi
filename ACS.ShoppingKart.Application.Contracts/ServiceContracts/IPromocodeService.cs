using ACS.ShoppingKart.Application.Contracts.Models;

namespace ACS.ShoppingKart.Application.Contracts.ServiceContracts
{
    public interface IPromocodeService
    {
        void Apply(DiscountRequest discountRequest);
    }
}

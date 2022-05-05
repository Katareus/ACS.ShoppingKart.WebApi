using ACS.ShoppingKart.Application.Contracts.Models;
using ACS.ShoppingKart.Application.Contracts.ServiceContracts;
using ACS.ShoppingKart.Application.Impl.Validations;

namespace ACS.ShoppingKart.Application.Impl.Services
{
    public class PromocodeService : IPromocodeService
    {
        public void Apply(DiscountRequest discountRequest)
        {
            DiscountValidations.DiscountRequestValidation(discountRequest);



            throw new System.NotImplementedException();
        }
    }
}

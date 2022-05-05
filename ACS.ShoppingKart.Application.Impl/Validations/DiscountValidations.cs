using ACS.ShoppingKart.Application.Contracts.Models;
using System;

namespace ACS.ShoppingKart.Application.Impl.Validations
{
    public class DiscountValidations
    {
        public static void DiscountRequestValidation(DiscountRequest discountRequest)
        {
            if (string.IsNullOrEmpty(discountRequest?.OrderId))
            {
                throw new ArgumentException("OrderId cannot be null or empty");
            }
            if (string.IsNullOrEmpty(discountRequest?.Promocode))
            {
                throw new ArgumentException("Promocode cannot be null or empty");
            }
        }
    }
}

using System;

namespace ACS.ShoppingKart.Application.Contracts.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string orderId)
            : base($"Order with id {orderId} not found")
        {
        }
    }
}

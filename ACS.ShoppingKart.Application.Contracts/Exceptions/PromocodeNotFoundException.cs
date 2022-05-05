using System;

namespace ACS.ShoppingKart.Application.Contracts.Exceptions
{
    public class PromocodeNotFoundException : Exception
    {
        public PromocodeNotFoundException(string promocodeId)
            : base($"Promocode with id {promocodeId} not found")
        {
        }
    }
}

using ACS.ShoppingKart.Domain.Entities;
using System.Collections.Generic;

namespace ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts
{
    public interface IOrderProductRepository
    {
        IEnumerable<OrderProduct> GetByOrderId(string orderId);
    }
}

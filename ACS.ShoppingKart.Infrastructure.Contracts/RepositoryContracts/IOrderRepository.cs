using ACS.ShoppingKart.Domain.Entities;

namespace ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts
{
    public interface IOrderRepository
    {
        Order GetById(string id);
        void UpdateOrder(Order order);
    }
}

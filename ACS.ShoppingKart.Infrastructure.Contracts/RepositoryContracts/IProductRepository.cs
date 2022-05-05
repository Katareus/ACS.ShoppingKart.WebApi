using ACS.ShoppingKart.Domain.Entities;

namespace ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts
{
    public interface IProductRepository
    {
        Product GetById(string id);
    }
}

using ACS.ShoppingKart.Domain.Entities;

namespace ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts
{
    public interface IPromocodeRepository
    {
        Promocode GetById(string id);
    }
}

using ACS.ShoppingKart.Application.Contracts.Exceptions;
using ACS.ShoppingKart.Domain.Entities;
using ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts;
using System.Collections.Generic;
using System.Linq;

namespace ACS.ShoppingKart.Infrastructure.Impl.Repositories
{
    public class PromocodeRepository : IPromocodeRepository
    {
        private readonly AppDbContext _appDbContext;

        public PromocodeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Promocode> AllPromocodes => _appDbContext.Promocodes;

        public Promocode GetById(string id)
        {
            var promocode = AllPromocodes.FirstOrDefault(p => p.Id == id);

            if (promocode == null) throw new PromocodeNotFoundException(id);

            return promocode;
        }
    }
}

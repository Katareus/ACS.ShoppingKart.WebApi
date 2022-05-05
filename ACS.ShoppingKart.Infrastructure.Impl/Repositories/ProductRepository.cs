using ACS.ShoppingKart.Domain.Entities;
using ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.ShoppingKart.Infrastructure.Impl.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> AllProducts => _appDbContext.Products;

        public Product GetById(string id)
        {
            return AllProducts.FirstOrDefault(p => p.Id == id);
        }
    }
}

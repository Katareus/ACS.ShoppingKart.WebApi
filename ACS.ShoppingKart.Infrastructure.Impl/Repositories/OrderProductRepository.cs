using ACS.ShoppingKart.Domain.Entities;
using ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.ShoppingKart.Infrastructure.Impl.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<OrderProduct> AllOrders => _appDbContext.OrderProducts;

        public IEnumerable<OrderProduct> GetByOrderId(string orderId)
        {
            return AllOrders.Where(p => p.Order.Id == orderId);
        }
    }
}

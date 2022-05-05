using ACS.ShoppingKart.Domain.Entities;
using ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.ShoppingKart.Infrastructure.Impl.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Order> AllOrders => _appDbContext.Orders;

        public Order GetById(string id)
        {
            return AllOrders.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateOrder(Order order)
        {
            order.UpdateDate = DateTime.UtcNow;

            _appDbContext.Orders.Update(order);

            _appDbContext.SaveChanges();
        }

    }
}

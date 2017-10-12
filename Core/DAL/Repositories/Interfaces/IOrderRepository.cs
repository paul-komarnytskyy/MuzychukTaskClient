using Core.Model;
using System;
using System.Collections.Generic;

namespace Core.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> GetOrders();

        Order GetOrder(int orderID);

        Order AddOrder(Order order);

        Order GetCurrentCart(int userID);

        bool DeleteOrder(int orderID);

        bool UpdateOrder(Order order);

        bool Save();
    }
}

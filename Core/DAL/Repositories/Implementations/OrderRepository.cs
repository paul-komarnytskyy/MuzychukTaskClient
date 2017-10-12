using System.Collections.Generic;
using Core.DAL.Repositories.Interfaces;
using System.Data.Entity;
using System.Linq;
using Core.Model;
using System;

namespace Core.DAL.Repositories.Implementations
{
    class OrderRepository : IOrderRepository
    {
        private OnlineShopEntities context;

        public OrderRepository(OnlineShopEntities context)
        {
            this.context = context;
        }

        public Order AddOrder(Order order)
        {
            return context.Orders.Add(order);
        }

        public bool DeleteOrder(int orderID)
        {
            var order = GetOrder(orderID);
            if (order != null)
            {
                context.Orders.Remove(order);
                return true;
            }

            return false;
        }

        public Order GetCurrentCart(int userID)
        {
            return GetOrders().FirstOrDefault(o => o.UserID == userID && o.Status == (int)OrderStatus.Cart) ?? new Order { UserID = userID, Status = (int)OrderStatus.Cart };
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.ToList();
        }

        public Order GetOrder(int orderID)
        {
            return context.Orders.Find(orderID);
        }

        public bool Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool UpdateOrder(Order order)
        {
            if (context.Orders.Find(order.ID) != null)
            {
                context.Entry(order).State = EntityState.Modified;
                return true;
            }

            return false;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

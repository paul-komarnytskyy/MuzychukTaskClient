using Core.DAL.Repositories;
using Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web.API.Controllers
{
    public class OrdersController : ApiController
    {
        [HttpGet]
        public List<Order> GetOrders()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.OrderRepository.GetOrders().ToList();
            }
        }

        [HttpGet]
        public Order GetOrder(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var order = uow.OrderRepository.GetOrder(id);
                if (order == null)
                    throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

                return order;
            }
        }

        [HttpPost]
        public Order AddOrder(Order order)
        {
            using (var uow = new UnitOfWork())
            {
                var added = uow.OrderRepository.AddOrder(order);
                return added;
            }
        }

        [HttpPut]
        public bool UpdateOrder(Order order)
        {
            using (var uow = new UnitOfWork())
            {
                var result = uow.OrderRepository.UpdateOrder(order);
                if (!result)
                {
                    throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
                }

                return result;
            }
        }
    }
}

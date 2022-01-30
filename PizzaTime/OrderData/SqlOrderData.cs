using PizzaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.OrderData
{
    public class SqlOrderData : IOrderData
    {
        private OrderContext _orderContext;
        public SqlOrderData(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }
        public OrderModel AddOrder(OrderModel order)
        {
             order.Id = Guid.NewGuid();
            _orderContext.Order.Add(order);
            _orderContext.SaveChanges();
            return order;
        }

        public bool DeleteOrder(OrderModel orderToDelete)
        {
            bool deleteSuccess = false;

             _orderContext.Order.Remove(orderToDelete);
            int success = _orderContext.SaveChanges();

            if (success == 1)
            {
                deleteSuccess = true;
            }

            return deleteSuccess;
        }

        public OrderModel EditOrder(OrderModel editOrder)
        {
            _orderContext.Order.Update(editOrder);
            _orderContext.SaveChanges();
            return editOrder;
        }

        public OrderModel GetOrder(Guid id)
        {
            return _orderContext.Order.FirstOrDefault(x => x.Id == id);
        }

        public List<OrderModel> GetOrders()
        {
            return _orderContext.Order.ToList();
        }
    }
}

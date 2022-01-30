using PizzaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.OrderData
{
    public interface IOrderData
    {
        List<OrderModel> GetOrders();

        OrderModel GetOrder(Guid id);

        OrderModel AddOrder(OrderModel order);

        bool DeleteOrder(OrderModel order);

        OrderModel EditOrder(OrderModel order);

    }
}

using PizzaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.OrderData
{
    // public class MockOrderData : IOrderData
    // {
    //private List<OrderModel> orders = new List<OrderModel>()
    //{
    //    new OrderModel()
    //    {
    //        Id = Guid.NewGuid(), Name = "jimbob"
    //    },
    //    new OrderModel()
    //    {
    //        Id = Guid.NewGuid(), Name = "Mick"
    //    }
    //};

    //public OrderModel AddOrder(OrderModel order)
    //{
    //    order.Id = Guid.NewGuid();
    //    orders.Add(order);
    //    return order; 
    //}

    //public void DeleteOrder(OrderModel order)
    //{
    //    orders.Remove(order);
    //}

    //public OrderModel EditOrder(OrderModel order)
    //{
    //    var existingOrder = GetOrder(order.Id);
    //    existingOrder.Name = order.Name;
    //    return existingOrder;
    //}

    //public OrderModel GetOrder(Guid id)
    //{
    //    return orders.FirstOrDefault(x => x.Id == id);
    //}

    //public List<OrderModel> GetOrders()
    //{
    //    return orders;
    //}
    //  }
}

using Microsoft.AspNetCore.Mvc;
using PizzaTime.Models;
using PizzaTime.OrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.Controllers
{
    public class OrderController : Controller
    {
        private IOrderData _orderData;
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public OrderController(IOrderData orderData)
        {
            _orderData = orderData;
        }

        [HttpGet]
        [Route("api/[controller]")] 
        public IActionResult GetOrders()
        {
            return Ok(_orderData.GetOrders());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")] 
        public IActionResult GetOrder(Guid id)
        {
            var order = _orderData.GetOrder(id);

            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound("OrderId: " + id + ", does not exist");
            }

        }

        [HttpPost]
        [Route("api/[controller]")] 
        public IActionResult GetOrder(OrderModel order)
        {
            _orderData.AddOrder(order);

            //return 202 status - Created
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + order.Id,
                order); 
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            var order = _orderData.GetOrder(id);

            if (order != null)
            {
                if(_orderData.DeleteOrder(order))
                {
                    return Ok("Delete Success");
                }
                else
                {
                    return Ok("Delete FAIL");
                }
            }
            else
            {
                return NotFound("OrderId: " + id + ", does not exist");
            }
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditOrder(Guid id, OrderModel order)
        {
            var existingOrder = _orderData.GetOrder(id);

            if (existingOrder != null)
            {
                //Null is passed if PersonsName isnt included in the parameters in the PATCH call 
                if (order.PersonsName != null)
                {
                    if (existingOrder.PersonsName != order.PersonsName)
                    {
                        existingOrder.PersonsName = order.PersonsName;
                    }
                }

                //Null is passed if PizzaName isnt included in the parameters in the PATCH call 
                if (order.PizzaName != null)
                {
                    if (existingOrder.PizzaName != order.PizzaName)
                    {
                        existingOrder.PizzaName = order.PizzaName;
                    }
                }

                //0 is passed if PizzaSize isnt included in the parameters in the PATCH call 
                if (order.PizzaSize != 0)
                {
                    if (existingOrder.PizzaSize != order.PizzaSize)
                    {
                        existingOrder.PizzaSize = order.PizzaSize;
                    }
                }

                //"01/01/0001 00:00:00" is passed if DateOrdered isnt included in the parameters in the PATCH call 
                if (order.DateOrdered.ToString() != "01/01/0001 00:00:00")
                {
                    if (existingOrder.DateOrdered != order.DateOrdered)
                    {
                        existingOrder.DateOrdered = order.DateOrdered;
                    }
                }

                //0 is passed if TotalPrice isnt included in the parameters in the PATCH call 
                if (order.TotalPrice != 0)
                {
                    if (existingOrder.TotalPrice != order.TotalPrice)
                    {
                        existingOrder.TotalPrice = order.TotalPrice;
                    }
                }

                    _orderData.EditOrder(existingOrder);
            }

            return Ok(existingOrder);
        }
    }
}

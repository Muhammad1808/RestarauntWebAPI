using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntWebAPI.Context;
using RestarauntWebAPI.Models;

namespace RestarauntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MyContext _context;
        public OrderController(MyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order.Id;
        }

        [HttpGet]
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        [HttpDelete]
        public int DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();

            return id;
        }

        [HttpPut]
        public Order UpdateOrder(Order order)
        {
            var updatedOrder = _context.Orders.Update(order);
            _context.SaveChanges();
            return order;
        }
    }
}

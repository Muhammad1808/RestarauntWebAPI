using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntWebAPI.Context;
using RestarauntWebAPI.Models;

namespace RestarauntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly MyContext _context;
        public OrderDetailsController(MyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int CreateOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Add(orderDetails);
            _context.SaveChanges();
            return orderDetails.Id;
        }

        [HttpGet]
        public List<OrderDetails> GetAllOrderDetails()
        {
            return _context.OrderDetails.ToList();
        }

        [HttpDelete]
        public int DeleteOrderDetails(int id)
        {
            var orderDetails = _context.OrderDetails.Find(id);
            _context.OrderDetails.Remove(orderDetails);
            _context.SaveChanges();

            return id;
        }

        [HttpPut]
        public OrderDetails UpdateOrderDetails(OrderDetails orderDetails)
        {
            var updatedOrderDetails = _context.OrderDetails.Update(orderDetails);
            _context.SaveChanges();
            return orderDetails;
        }
    }
}

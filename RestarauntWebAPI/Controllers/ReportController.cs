using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntWebAPI.Context;
using RestarauntWebAPI.Models;

namespace RestarauntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly MyContext _context;

        public ReportController(MyContext context)
        {
            _context = context;
        }
        [HttpGet("employee")]
        public List<GetReportEmployee> GetAllSortByEmployees()
        {
            return _context.Employees.Select(e => new
            {
                Employee=e,
                OrderCount=e.Orders.Count()
            }).OrderByDescending(e => e.OrderCount).Select(e => new GetReportEmployee() 
            { Name = e.Employee.Name, Orders = e.OrderCount }).ToList();   
        }

        [HttpGet("product")]
        public List<GetReportProduct> GetAllSortByProduct()
        {
            return _context.Products.Select(p => new
            {
                Product=p,
                ProductCount=_context.OrderDetails.Count(od=>od.ProductId==p.Id)
            }).OrderByDescending(p=>p.ProductCount).Select(p=>new GetReportProduct() 
            { Name=p.Product.Name,Orders=p.ProductCount}).ToList();
        }

        [HttpGet("category")]
        public List<GetReportCategories> GetAllSortByCategory()
        {
            return _context.Categories.Select(c => new
            {
                Category=c,
                CategoryCount=_context.OrderDetails.Count(od=>od.Product.CategoryId==c.Id)
            }).OrderByDescending(c=>c.CategoryCount).Select(c=>new GetReportCategories()
            { Name=c.Category.Name,Orders=c.CategoryCount}).ToList();
        }
    }
}
  
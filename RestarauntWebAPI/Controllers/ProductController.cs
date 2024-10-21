using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntWebAPI.Context;
using RestarauntWebAPI.Models;

namespace RestarauntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyContext _context;
        public ProductController(MyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product.Id;
        }

        [HttpGet]
        public List<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }

        [HttpDelete]
        public int DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();

            return id;
        }

        [HttpPut]
        public Product UpdateProduct(Product product)
        {
            var updatedProduct = _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}

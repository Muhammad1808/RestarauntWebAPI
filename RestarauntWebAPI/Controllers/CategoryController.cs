using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntWebAPI.Context;
using RestarauntWebAPI.Models;

namespace RestarauntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyContext _context;
        public CategoryController(MyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category.Id;
        }

        [HttpGet]
        public List<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }

        [HttpDelete]
        public int DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return id;
        }

        [HttpPut]
        public Category UpdateCategory(Category category)
        {
            var updatedCategory = _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntWebAPI.Context;
using RestarauntWebAPI.Models;

namespace RestarauntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestarauntController : ControllerBase
    {
        private readonly MyContext _context;
        public RestarauntController(MyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int CreateRestaraunt(Restaraunt restaraunt)
        {
            _context.Restaraunts.Add(restaraunt);
            _context.SaveChanges();

            return restaraunt.Id;
        }

        [HttpGet]
        public List<Restaraunt> GetAllRestaraunt()
        {
            return _context.Restaraunts.ToList();
        }

        [HttpDelete]
        public int DeleteRestaraunt(int id)
        {
            var restaraunt = _context.Restaraunts.Find(id);
            _context.Restaraunts.Remove(restaraunt);
            _context.SaveChanges();

            return id;
        }

        [HttpPut]
        public Restaraunt UpdateRestaraunt(Restaraunt restaraunt)
        {
            var updatedRestaraunt = _context.Restaraunts.Update(restaraunt);
            _context.SaveChanges();
            return restaraunt;
        }
    }
}

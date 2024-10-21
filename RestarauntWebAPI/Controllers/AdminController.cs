using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntWebAPI.Context;
using RestarauntWebAPI.Models;

namespace RestarauntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MyContext _context;
        public AdminController(MyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int CreateAdmin(RestarauntAdmin restarauntAdmin)
        {
            _context.RestarauntAdmins.Add(restarauntAdmin);
            _context.SaveChanges();

            return restarauntAdmin.Id;
        }

        [HttpGet]
        public List<RestarauntAdmin> GetAllAdmins()
        {
            return _context.RestarauntAdmins.ToList();
        }

        [HttpDelete]
        public int DeleteAdmin(int id)
        {
            var admin = _context.RestarauntAdmins.Find(id);
            _context.RestarauntAdmins.Remove(admin);
            _context.SaveChanges();

            return id;
        }

        [HttpPut]
        public RestarauntAdmin UpdateAdmin(RestarauntAdmin restarauntAdmin)
        {
            var updatedAdmin = _context.RestarauntAdmins.Update(restarauntAdmin);
            _context.SaveChanges();
            return restarauntAdmin;
        }
    }
}

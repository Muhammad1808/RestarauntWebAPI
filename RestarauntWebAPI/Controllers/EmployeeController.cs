using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestarauntWebAPI.Context;
using RestarauntWebAPI.Models;

namespace RestarauntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MyContext _context;
        public EmployeeController(MyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee.Id;
        }

        [HttpGet]
        public List<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        [HttpDelete]
        public int DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return id;
        }

        [HttpPut]
        public Employee UpdateEmployee(Employee employee)
        {
            var updatedEmployee = _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;
        }
    }
}

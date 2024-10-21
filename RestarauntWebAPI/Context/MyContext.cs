using Microsoft.EntityFrameworkCore;
using RestarauntWebAPI.Models;

namespace RestarauntWebAPI.Context
{
    public class MyContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<RestarauntAdmin> RestarauntAdmins { get; set; }
        public DbSet<Restaraunt> Restaraunts { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    }
}

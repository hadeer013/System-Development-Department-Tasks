using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.Models;

namespace ProductOrderManagement.ApplicationContext
{
    public class CustomerOrderContext : DbContext
    {
        public CustomerOrderContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }    
    }
}

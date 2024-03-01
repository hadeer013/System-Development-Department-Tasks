using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.Models;

namespace ProductOrderManagement.ApplicationContext
{
    public class CustomerOrderContext : DbContext
    {
        public CustomerOrderContext():base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-0054Q2J\\SQLEXPRESS;database=CustomerOrder_TaskD5;trusted_connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}

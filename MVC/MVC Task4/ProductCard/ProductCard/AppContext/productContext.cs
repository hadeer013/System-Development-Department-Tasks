using Microsoft.EntityFrameworkCore;
using ProductCard.Models;

namespace ProductCard.AppContext
{
    public class productContext : DbContext
    {
        public productContext():base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-0054Q2J\\SQLEXPRESS;database=ProductCard;trusted_connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}

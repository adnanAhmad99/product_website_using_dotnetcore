using Microsoft.EntityFrameworkCore;
using MainApp.Models;

namespace MainApp.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id=1,ProductName="firsty",Quantity=10, ImageUrl=""},
                new Product { Id=2,ProductName="firsty",Quantity=40, ImageUrl=""},
                new Product { Id=3,ProductName="firsty",Quantity=20, ImageUrl=""},
                new Product { Id=4,ProductName="firsty",Quantity=23, ImageUrl = "" }
                );
        }
    }
}

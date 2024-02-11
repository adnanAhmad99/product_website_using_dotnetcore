using Microsoft.EntityFrameworkCore;
using MainApp.Models;

namespace MainApp.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Male" },
                new Category { CategoryId = 2, CategoryName = "Female" },
                new Category { CategoryId = 3, CategoryName = "Other" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "firsty", Quantity = 10, ImageUrl = "/images/products/d01fdb34-f60a-4952-9eb1-9bd9c09d86a9.jpg", CategoryDataId = 1 },
                new Product { ProductId = 2, ProductName = "secondy", Quantity = 40, ImageUrl = "/images/products/021b827f-cf1a-412a-8c10-189a898dbf44.jpg", CategoryDataId = 2 }
                );             

               
        }
    }
}

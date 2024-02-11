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
                new Category { CategoryId = 1, CategoryName = "Scifi" },
                new Category { CategoryId = 2, CategoryName = "Isekei" },
                new Category { CategoryId = 3, CategoryName = "Fantacy" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "firsty", Quantity = 10, ImageUrl = "", CategoryDataId = 1 },
                new Product { ProductId = 2, ProductName = "secondy", Quantity = 40, ImageUrl = "", CategoryDataId = 2 },
                new Product { ProductId = 3, ProductName = "thirdy", Quantity = 20, ImageUrl = "", CategoryDataId = 3 },
                new Product { ProductId = 4, ProductName = "forthdy", Quantity = 23, ImageUrl = "", CategoryDataId = 2 }
                );             

               
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MainApp.DataAccess.Data;
using MainApp.Models;
using MainApp.DataAccess.Repository.IRepostiory;

namespace MainApp.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProduct
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void Update(Product entity)
        {
            _db.Product.Update(entity);

        }
    }
}

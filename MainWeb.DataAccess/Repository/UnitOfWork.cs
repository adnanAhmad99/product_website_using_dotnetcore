using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApp.DataAccess.Data;
using MainApp.DataAccess.Repository.IRepostiory;


namespace MainApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IProduct Product { get; private set; }

        public ICategory Category { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db= db;
            Product = new ProductRepository(_db);
            Category = new CategoryRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

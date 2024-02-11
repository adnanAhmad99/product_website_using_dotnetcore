using MainApp.DataAccess.Data;
using MainApp.DataAccess.Repository.IRepostiory;
using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategory
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void update(Category obj)
        {
            _db.Category.Update(obj);   
        }
    }
}

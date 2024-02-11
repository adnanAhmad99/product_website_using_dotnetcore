using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.DataAccess.Repository.IRepostiory
{
    public interface ICategory:IRepository<Category>
    {
        void update(Category obj);
    }
}

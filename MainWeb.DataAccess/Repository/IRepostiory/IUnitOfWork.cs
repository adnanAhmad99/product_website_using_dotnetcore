using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.DataAccess.Repository.IRepostiory
{
    public interface IUnitOfWork
    {
        IProduct Product { get; }
        void Save();
    }
}

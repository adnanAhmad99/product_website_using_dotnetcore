using MainApp.Models;

namespace MainApp.DataAccess.Repository.IRepostiory
{
    public interface IProduct : IRepository<Product>
    {
        void Update(Product entity);
    }
}

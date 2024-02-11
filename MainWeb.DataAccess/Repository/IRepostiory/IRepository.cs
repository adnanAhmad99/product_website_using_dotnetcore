using System.Linq.Expressions;

namespace MainApp.DataAccess.Repository.IRepostiory
{
    public interface IRepository<T> where T : class
    {

        IEnumerable<T> GetAll(bool includeDataPara = false);

        T Get(Expression<Func<T, bool>> filter, bool includeDataPara = false);

        void Add(T entity);
        void Remove(T entity);
    }
}

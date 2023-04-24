using System.Linq.Expressions;
namespace _01_Framework.Domain
{
    public interface IRepository<Tkey, T> where T : class
    {
        T GetBy(Tkey id);
        List<T> Get();
        void Add(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
        void Save();
    }
}
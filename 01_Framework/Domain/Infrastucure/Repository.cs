
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace _01_Framework.Domain.Infrastucure
{
    public class Repository<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }


        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(Tkey id)
        {
            return _context.Find<T>(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
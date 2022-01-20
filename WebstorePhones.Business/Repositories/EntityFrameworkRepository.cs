using System.Diagnostics.CodeAnalysis;
using System.Linq;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Repositories
{
    [ExcludeFromCodeCoverage]
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        public EntityFrameworkRepository(DataContext context)
        {
            _context = context;
        }

        public int Id { get; set; }

        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        // Oplossing van Thomas, maar kan niet omdat het GetAll() moet zijn, dus zonder parameters.
        //public IEnumerable<T> GetAll(Action<IQueryable<T>> predicate)
        //{
        //    var set = _context.Set<T>();
        //    predicate.Invoke(set);
        //    return set.AsEnumerable();
        //}

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(long id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(long id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(long id)
        {
            return _context.Set<T>().Single(x => x.Id == id);
        }
    }
}
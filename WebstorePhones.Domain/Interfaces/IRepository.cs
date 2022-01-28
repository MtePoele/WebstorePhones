using System.Linq;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all.
        /// </summary>
        /// <returns>IEnumerable of T.</returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// Get T by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T.</returns>
        T GetById(long id);
        /// <summary>
        /// Adds a T to the database.
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);
        /// <summary>
        /// Delete by id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
    }
}

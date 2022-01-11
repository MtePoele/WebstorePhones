using System.Collections.Generic;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all.
        /// </summary>
        /// <returns>IEnumerable of T.</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Get T by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T.</returns>
        T GetById(long id);
        /// <summary>
        /// Create a T.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>T.</returns>
        T Create(T entity);
        /// <summary>
        /// Delete by id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebstorePhones.Domain.Interfaces
{

    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Fills a record of type TEntity.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        Func<SqlDataReader, TEntity> ConvertEntry { set; }
        /// <summary>
        /// Get a TEntity.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        TEntity Get(string queryString);
        /// <summary>
        /// Get an IEnumerable<TEntity>.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetRecords(string queryString);
        /// <summary>
        /// Execute the nonquery. So it doesn't return anything.
        /// </summary>
        /// <param name="command"></param>
        void ExecuteNonQuery(SqlCommand command);
    }
}

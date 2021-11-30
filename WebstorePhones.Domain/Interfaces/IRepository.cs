using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity PopulateRecord(SqlDataReader reader);
        TEntity Get(string queryString);
        IEnumerable<TEntity> GetRecords(string queryString);
        void ExecuteNonQuery(SqlCommand command);
    }
}

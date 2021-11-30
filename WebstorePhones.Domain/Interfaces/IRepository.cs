using System.Collections.Generic;
using System.Data.SqlClient;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {


    }
}

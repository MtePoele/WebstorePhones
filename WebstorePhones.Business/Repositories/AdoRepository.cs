using System.Collections.Generic;
using System.Data.SqlClient;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Repositories
{
    public class AdoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private static SqlConnection _connection;

        public AdoRepository()
        {
            _connection = new SqlConnection(Constants.ConnectionString);
        }

        public virtual TEntity ReadPhone(SqlDataReader reader)
        {
            return null;
        }

        public IEnumerable<TEntity> GetRecords(string queryString)
        {
            SqlCommand command = new(queryString, _connection);

            var list = new List<TEntity>();
            //command.Connection = _connection;
            _connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                        list.Add(ReadPhone(reader));
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }
            return list;
        }
        protected TEntity GetRecord(SqlCommand command)
        {
            TEntity record = null;
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        record = ReadPhone(reader);
                        break;
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }
            return record;
        }
    }
}

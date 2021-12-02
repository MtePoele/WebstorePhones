using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Repositories
{
    public class AdoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private static SqlConnection _connection;

        public AdoRepository()
        {
            _connection = new SqlConnection(Constants.ConnectionString);
        }

        public virtual TEntity PopulateRecord(SqlDataReader reader)
        {
            return null;
        }

        public virtual TEntity Get(string queryString)
        {
            SqlCommand command = new(queryString, _connection);
            TEntity record = null;

            _connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                        record = PopulateRecord(reader);
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

        public virtual IEnumerable<TEntity> GetRecords(string queryString)
        {
            SqlCommand command = new(queryString, _connection);

            var list = new List<TEntity>();
            _connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                        list.Add(PopulateRecord(reader));
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

        public virtual void ExecuteNonQuery(SqlCommand command)
        {
            command.Connection = _connection;

            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}

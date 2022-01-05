using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Repositories
{
    public class AdoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Func<SqlDataReader, TEntity> PopulateRecord { get; set; }

        private static SqlConnection _connection;

        public AdoRepository()
        {
            _connection = new SqlConnection(Constants.ConnectionString);
        }

        public TEntity Get(string queryString)
        {
            SqlCommand command = new(queryString, _connection);

            TEntity record = null;
            SqlDataReader reader = null;
            try
            {
                _connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                    record = PopulateRecord(reader);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                _connection.Close();
            }
            return record;
        }

        public IEnumerable<TEntity> GetRecords(string queryString)
        {
            SqlCommand command = new(queryString, _connection);

            List<TEntity> list = new();
            SqlDataReader reader = null;
            try
            {
                _connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(PopulateRecord(reader));
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                _connection.Close();
            }
            return list;
        }

        public void ExecuteNonQuery(SqlCommand command)
        {
            command.Connection = _connection;

            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}

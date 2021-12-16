using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Repositories
{
    public class AdoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Func<SqlDataReader, TEntity> ConvertEntry { private get; set; }
     
        private static SqlConnection _connection;
        private readonly IRepository<Brand> brandRepository;

        public AdoRepository(IRepository<Brand> _brandRepository)
        {
            _connection = new SqlConnection(Constants.ConnectionString);
            brandRepository = _brandRepository;
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
                    record = ConvertEntry(reader);
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
                    list.Add(ConvertEntry(reader));
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

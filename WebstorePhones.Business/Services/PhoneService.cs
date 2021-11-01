using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly string _connectionString = Constants.ConnectionString;

        public Phone Get(int id)
        {
            Phone phone = new();

            string queryString = $"SELECT * FROM phoneshop.dbo.phones WHERE ID = {id}";

            using (SqlConnection connection = new(_connectionString))
            {
                SqlCommand command = new(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        phone = ReadPhone(reader);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return phone;
        }

        public IEnumerable<Phone> Get()
        {
            List<Phone> phones = new();

            string queryString = "SELECT * FROM phoneshop.dbo.phones";

            using (SqlConnection connection = new(_connectionString))
            {
                SqlCommand command = new(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Phone phone = ReadPhone(reader);
                        phones.Add(phone);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return phones.OrderBy(x => x.Brand);
        }

        public IEnumerable<Phone> Search(string query)
        {
            List<Phone> phones = new();

            string queryString =
                $"SELECT *" +
                $"FROM phoneshop.dbo.phones " +
                $"WHERE Brand LIKE '%{query}%' OR Type LIKE '%{query}%' OR Description LIKE '%{query}%'";

            using (SqlConnection connection = new(_connectionString))
            {
                SqlCommand command = new(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Phone phone = ReadPhone(reader);
                        phones.Add(phone);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return phones.OrderBy(x => x.Brand);
        }

        public Phone ReadPhone(SqlDataReader reader)
        {
            return new Phone()
            {
                Id = reader.GetInt64(0),
                Brand = reader.GetString(1),
                Type = reader.GetString(2),
                Description = reader.GetString(3),
                PriceWithTax = reader.GetDecimal(4),
                Stock = reader.GetInt32(5)
            };
        }
    }
}

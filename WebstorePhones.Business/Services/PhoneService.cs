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
        const string connectionString = "Data Source=LAPTOP-I9V7KFJQ;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Phone Get(int id)
        {
            return new Phone();

            Phone phone = new Phone();

            string queryString = $"SELECT * FROM phoneshop.dbo.phones WHERE ID = {id}";

            using (SqlConnection connection = new(connectionString))
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

            using (SqlConnection connection = new(connectionString))
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

        private Phone ReadPhone(SqlDataReader reader)
        {
            return new()
            {
                Id = reader.GetInt64(0),
                Brand = reader.GetString(1),
                Type = reader.GetString(2),
                Description = reader.GetString(3),
                PriceWithTax = reader.GetDecimal(4),
                Stock = reader.GetInt32(5)
            };
        }

        public IEnumerable<Phone> Search(string query)
        {
            return new List<Phone>();

            //query = query.ToLower();
            //return phones.Where(x =>
            //    x.Brand.ToLower().Contains(query) ||
            //    x.Type.ToLower().Contains(query) ||
            //    x.Description.ToLower().Contains(query))
            //    .OrderBy(x => x.Brand);
        }
    }
}

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

            string queryString =
                "SELECT p.Id, b.Brand, p.Type, p.Description, p.PriceWithTax, p.Stock " +
                "FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
                "WHERE p.BrandId = {id}";

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

            string queryString = 
                "SELECT p.Id, b.Brand, p.Type, p.Description, p.PriceWithTax, p.Stock " +
                "FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
                "WHERE p.BrandId = b.Id";

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
                "SELECT phones.Id, brands.Brand, phones.Type, phones.Description, phones.PriceWithTax, phones.Stock " +
                "FROM phoneshop.dbo.phones " +
                "INNER JOIN brands ON phones.BrandId = brands.Id " +
                $"WHERE brands.Brand LIKE '%{query}%' OR phones.Type LIKE '%{query}%' OR phones.Description LIKE '%{query}%'";

                //$"SELECT *" +
                //$"FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
                //$"WHERE Brand LIKE '%{query}%' OR Type LIKE '%{query}%' OR Description LIKE '%{query}%'";

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

        public int AddMissingPhones(List<Phone> phones)
        {
            int phonesAdded = 0;

            foreach (var phone in phones)
            {
                if (PhoneNotInDatabase(phone))
                {
                    AddPhoneToDatabase(phone);
                    phonesAdded++;
                }
            }
            return phonesAdded;
        }

        private bool PhoneNotInDatabase(Phone phoneToLookFor)
        {
            List<Phone> phones = new();

            string queryString =
                $"SELECT *" +
                $"FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
                $"WHERE b.Brand LIKE '{phoneToLookFor.Brand}' AND p.Type LIKE '{phoneToLookFor.Type}'";

            //    $"SELECT *" +
            //    $"FROM phoneshop.dbo.phones " +
            //    $"WHERE Brand LIKE '{phoneToLookFor.Brand}' AND Type LIKE '{phoneToLookFor.Type}'";

            using (SqlConnection connection = new(_connectionString))
            {
                SqlCommand command = new(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        PhoneService phoneService = new();
                        Phone p = phoneService.ReadPhone(reader);
                        phones.Add(p);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            if (phones.Count == 0)
                return true;
            else
                return false;
        }

        private void AddPhoneToDatabase(Phone phone)
        {
            
        }
    }
}

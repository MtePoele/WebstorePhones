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
            GetFromDataBase(queryString, (SqlDataReader reader) =>
            {
                phone = ReadPhone(reader);
            });
            return phone;
        }

        public IEnumerable<Phone> Get()
        {
            List<Phone> phones = new();
            string queryString =
            "SELECT p.Id, b.Brand, p.Type, p.Description, p.PriceWithTax, p.Stock " +
            "FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
            "WHERE p.BrandId = b.Id";
            GetFromDataBase(queryString, (SqlDataReader reader) =>
            {
                Phone phone = ReadPhone(reader);
                phones.Add(phone);
            });
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
            GetFromDataBase(queryString, (SqlDataReader reader) =>
            {
                Phone phone = ReadPhone(reader);
                phones.Add(phone);
            });
            return phones.OrderBy(x => x.Brand);
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

        private Phone ReadPhone(SqlDataReader reader)
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

        private bool PhoneNotInDatabase(Phone phoneToLookFor)
        {
            List<Phone> phones = new(); string queryString =
            $"SELECT * " +
            $"FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
            $"WHERE b.Brand LIKE '{phoneToLookFor.Brand}' AND p.Type LIKE '{phoneToLookFor.Type}'";
            GetFromDataBase(queryString, (SqlDataReader reader) =>
            {
                Phone p = ReadPhone(reader);
                phones.Add(p);
            }); if (phones.Count == 0)
                return true;
            else
                return false;
        }

        private long DoesBrandExistInDatabase(Phone phone)
        {
            return 0; // TODO return ID of brand if it is in database, otherwise add brand first and then return its ID. return id;
        }

        private void AddPhoneToDatabase(Phone phone)
        {
            // TODO call DoesBrandExistInDatabase(Phone phone), then add phone to db with returned brandid.
        }

        private void GetFromDataBase(string queryString, Action<SqlDataReader> DoStuff)
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(queryString, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DoStuff(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
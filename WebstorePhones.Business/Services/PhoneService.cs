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
            GetFromDatabase(queryString, (SqlDataReader reader) =>
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
            GetFromDatabase(queryString, (SqlDataReader reader) =>
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
            GetFromDatabase(queryString, (SqlDataReader reader) =>
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

        public void AddPhoneToDatabase(Phone phone)
        {
            using SqlConnection connection = new(_connectionString);
            string nonQueryString =
                $"IF NOT EXISTS (SELECT Brand FROM phoneshop.dbo.brands WHERE Brand = @Brand)" +
                $"BEGIN INSERT INTO phoneshop.dbo.brands (Brand) VALUES (@Brand) END " +
                $"INSERT INTO phoneshop.dbo.phones (BrandId, Type, Description, PriceWithTax, Stock) " +
                $"VALUES ((SELECT Id FROM phoneshop.dbo.brands WHERE Brand = @Brand), @Type, @Description, @PriceWithTax, @Stock)";

            SqlCommand command = new(nonQueryString, connection);
            command.Parameters.Add("@Brand", SqlDbType.VarChar).Value = phone.Brand;
            command.Parameters.Add("@Type", SqlDbType.VarChar).Value = phone.Type;
            command.Parameters.Add("@Description", SqlDbType.VarChar).Value = phone.Description;
            command.Parameters.Add("@PriceWithTax", SqlDbType.Decimal).Value = phone.PriceWithTax;
            command.Parameters.Add("@Stock", SqlDbType.BigInt).Value = phone.Stock;

            ExecuteNonQuery(connection, command);
        }

        public void Delete(long id)
        {
            using SqlConnection connection = new(_connectionString);
            string nonQueryString =
                $"DELETE FROM phoneshop.dbo.phones " +
                $"WHERE phones.Id = @Id ";

            SqlCommand command = new(nonQueryString, connection);
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;

            ExecuteNonQuery(connection, command);
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
            List<Phone> phones = new();

            string queryString =
            "SELECT phones.Id, brands.Brand, phones.Type, phones.Description, phones.PriceWithTax, phones.Stock " +
            "FROM phoneshop.dbo.phones " +
            "INNER JOIN brands ON phones.BrandId = brands.Id " +
            $"WHERE brands.Brand LIKE '{phoneToLookFor.Brand}' AND phones.Type LIKE '{phoneToLookFor.Type}'";
            GetFromDatabase(queryString, (SqlDataReader reader) =>
            {
                Phone phone = ReadPhone(reader);
                phones.Add(phone);
            });

            if (phones.Count == 0)
                return true;
            else
                return false;
        }

        private void GetFromDatabase(string queryString, Action<SqlDataReader> DoStuff)
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

        private static void ExecuteNonQuery(SqlConnection connection, SqlCommand command)
        {
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
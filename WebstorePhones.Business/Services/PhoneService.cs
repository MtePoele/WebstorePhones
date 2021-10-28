using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Services
{
    public class PhoneService : IPhoneService
    {
        const string connectionString = "Data Source=LAPTOP-I9V7KFJQ;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Phone Get(int id)
        {
            Phone phone = new();

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

        public IEnumerable<Phone> Search(string query)
        {
            List<Phone> phones = new();

            string queryString =
                $"SELECT *" +
                $"FROM phoneshop.dbo.phones " +
                $"WHERE Brand LIKE '%{query}%' OR Type LIKE '%{query}%' OR Description LIKE '%{query}%'";

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

        public List<Phone> ReadFromXmlFile(string xmlPath)
        {
            List<Phone> phones = new();

            using (XmlReader reader = XmlReader.Create(xmlPath))
            {
                Phone phone = new();

                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "Brand":
                                if (reader.Read())
                                    phone.Brand = reader.Value;
                                break;
                            case "Type":
                                if (reader.Read())
                                    phone.Type = reader.Value;
                                break;
                            case "Price":
                                if (reader.Read())
                                {
                                    decimal.TryParse(reader.Value, out decimal price);
                                    phone.PriceWithTax = price;
                                }
                                break;
                            case "Description":
                                if (reader.Read())
                                    phone.Description = reader.Value;
                                break;
                            case "Stock":
                                if (reader.Read())
                                {
                                    int.TryParse(reader.Value, out int stock);
                                    phone.Stock = stock;
                                    phones.Add(new Phone(phone));
                                }
                                break;
                        }
                    }
                }
            }
            return phones;
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
                $"FROM phoneshop.dbo.phones " +
                $"WHERE Brand LIKE '{phoneToLookFor.Brand}' AND Type LIKE '{phoneToLookFor.Type}'";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Phone p = ReadPhone(reader);
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
            // TODO Add phone to database somehow
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
    }
}

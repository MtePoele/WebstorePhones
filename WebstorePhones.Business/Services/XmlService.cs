using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Services
{
    public class XmlService
    {
        private readonly string _connectionString = Constants.ConnectionString;

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

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

        

        
    }
}

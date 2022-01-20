using System;
using System.Collections.Generic;
using System.Xml;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class XmlService : IXmlService
    {
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
                                    phone.Brand = new Brand()
                                    {
                                        BrandName = reader.Value
                                    };
                                break;
                            case "Type":
                                if (reader.Read())
                                    phone.Type = reader.Value;
                                break;
                            case "Price":
                                if (reader.Read())
                                {
                                    decimal price = Convert.ToDecimal(reader.Value);
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
                                    int stock = Convert.ToInt32(reader.Value);
                                    phone.Stock = stock;

                                    AddToList(phones, phone);
                                }
                                break;
                        }
                    }
                }
            }
            return phones;
        }

        private static void AddToList(List<Phone> phones, Phone phone)
        {
            phones.Add(new Phone()
            {
                Brand = new Brand()
                {
                    BrandName = phone.Brand.BrandName
                },
                Type = phone.Type,
                Description = phone.Description,
                PriceWithTax = phone.PriceWithTax,
                Stock = phone.Stock
            });
        }
    }
}

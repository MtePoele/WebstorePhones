﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Services
{
    public class XmlService
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
                                    phone.Brand = reader.Value;
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

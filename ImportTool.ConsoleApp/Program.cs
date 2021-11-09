using System;
using System.Collections.Generic;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Objects;

namespace ImportTool.ConsoleApp
{
    class Program
    {
        private static readonly PhoneService phoneService = new();
        private static List<Phone> phones = new();

        static void Main(string[] args)
        {
            XmlService xmlService = new();
            phones = xmlService.ReadFromXmlFile(args[0]);
            int phonesAdded = phoneService.AddMissingPhones(phones);
            Console.WriteLine($"{phonesAdded} new phones have been added.");
            Console.ReadLine();
        }
    }
}

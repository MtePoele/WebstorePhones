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
            while (true)
            {
                MainMenu(args[0]);
            }
        }

        private static void MainMenu(string filepath)
        {
            Console.WriteLine("Kies met een nummer welk bestand moet worden ingevoerd in de database.");
            Console.WriteLine("1. PhoneList001.xml");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    XmlService xmlService = new();
                    phones = xmlService.ReadFromXmlFile(filepath);
                    int phonesAdded = xmlService.AddMissingPhones(phones);
                    Console.WriteLine($"Er zijn { phonesAdded} nieuwe telefoons toegevoegd.");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ongeldige invoer");
                    break;
            }
            Console.WriteLine();
        }
    }
}

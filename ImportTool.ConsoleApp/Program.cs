using System;
using System.Collections.Generic;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Objects;

namespace ImportTool.ConsoleApp
{
    class Program
    {
        private static PhoneService phoneService = new();
        private const string xmlFilepath = @"C:\Users\rsmar\source\repos\WebstorePhones\PhoneList001.xml";
        private static List<Phone> phones = new();

        static void Main(string[] args)
        {
            while (true)
            {
                MainMenu();
            }
        }

        private static void MainMenu()
        {
            Console.WriteLine("Kies met een nummer welk bestand moet worden ingevoerd in de database.");
            Console.WriteLine("1. PhoneList001.xml");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    phones = phoneService.ReadFromXmlFile(xmlFilepath);
                    int phonesAdded = phoneService.AddMissingPhones(phones);
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

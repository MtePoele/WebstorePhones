using System;
using System.Collections.Generic;
using System.Linq;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones
{
    class Program
    {
        static Dictionary<int, Phone> phonesDictionary = new();
        private static PhoneService phoneService = new();

        static void Main(string[] args)
        {
            GetAllPhones();

            while (true)
            {
                MainMenu();
            }
        }

        private static void MainMenu()
        {
            foreach (var phone in phonesDictionary)
            {
                Console.WriteLine($"{phone.Key}. {phone.Value.Brand} \t{phone.Value.Type}");
            }
            Console.WriteLine($"{phonesDictionary.Count + 1}. Zoeken");
            Console.WriteLine($"{phonesDictionary.Count + 2}. Afsluiten");

            Console.Write("\nUw keuze: ");

            int userChoice = 0;

            try
            {
                userChoice = int.Parse(Console.ReadKey().KeyChar.ToString());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"Ongeldige invoer. Kies een nummer 0-{phonesDictionary.Count}.\n");
            }

            if (userChoice > 0 && userChoice <= phonesDictionary.Count)
            {
                Console.Clear();

                Phone phone = phonesDictionary[userChoice];
                PrintResults(phone);
            }
            else if (userChoice == phonesDictionary.Count + 1)
            {
                Console.Clear();
                Console.WriteLine($"Geef woord(en) op om naar te zoeken.");

                string searchInput = Console.ReadLine();
                if (searchInput.Length > 0)
                {
                    List<Phone> searchResults = phoneService.Search(searchInput).ToList();
                    Console.WriteLine();

                    if (searchResults.Count == 0)
                    {
                        Console.WriteLine("Uw zoekopdracht heeft niets opgeleverd.");
                    }
                    else
                    {
                        Console.Clear();
                        foreach (var phone in searchResults)
                        {
                            PrintResults(phone);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ongeldige invoer. Voer tenminste 1 teken in.");
                }

                Console.WriteLine("Druk op een toets om terug te gaan.");
                Console.ReadKey();
                Console.Clear();
            }
            else if (userChoice == phonesDictionary.Count + 2)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Ongeldige invoer. Kies een nummer 1-{phonesDictionary.Count}.\n");
            }
        }

        private static void GetAllPhones()
        {
            List<Phone> phonesList = phoneService.Get().ToList();

            for (int i = 0; i < phonesList.Count; i++)
            {
                phonesDictionary.Add(i + 1, phonesList[i]);
            }
        }

        private static void PrintResults(Phone phone)
        {
            Console.WriteLine($"Merk: {phone.Brand} \tType: {phone.Type} \tPrijs: {phone.PriceWithTax} \tExcl. BTW: {phone.PriceWithoutTax} \tVoorraad: {phone.Stock}");
            Console.WriteLine($"Beschrijving: {phone.Description}\n");
        }
    }
}

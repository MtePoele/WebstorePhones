using System;
using System.Collections.Generic;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                MainMenu();
            }
        }

        private static void MainMenu()
        {
            List<Phone> phones = PhoneService.GetAllPhones();
            PhoneService.SortList(phones);

            int i;
            for (i = 0; i < phones.Count; i++)
            {
                Console.WriteLine($"{i}. {phones[i].Brand} {phones[i].Type}");
            }
            Console.WriteLine($"{i}. Zoeken");

            i++;
            Console.WriteLine($"{i}. Afsluiten");
            
            Console.Write("\nUw keuze: ");

            int userChoice = -1;

            try
            {
                userChoice = int.Parse(Console.ReadKey().KeyChar.ToString());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"Ongeldige invoer. Kies een nummer 0-{phones.Count}.\n");
            }
            if (userChoice > -1 && userChoice < phones.Count)
            {
                Console.Clear();

                Phone phone = PhoneService.GetPhone(userChoice);
                PrintResults(phone);
            }
            else if (userChoice == phones.Count)
            {
                Console.Clear();
                Console.WriteLine($"Geef woord(en) op om naar te zoeken.");

                string searchInput = Console.ReadLine();
                if (searchInput.Length > 0)
                {
                    List<Phone> searchResults = PhoneService.Search(searchInput);
                    Console.WriteLine();

                    if (searchResults.Count == 0)
                    {
                        Console.WriteLine("Uw zoekopdracht heeft niets opgeleverd.");
                    }
                    else
                    {
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
            else if (userChoice == i)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer. Kies een nummer 0-4.\n");
            }
        }

        private static void PrintResults(Phone phone)
        {
            Console.WriteLine($"Merk: {phone.Brand} \tType: {phone.Type} \tPrijs: {phone.PriceAfterTax} \tExcl. BTW: {phone.PriceBeforeTax} \tVoorraad: {phone.Stock}");
            Console.WriteLine($"Beschrijving: {phone.Description}\n");
        }
    }
}

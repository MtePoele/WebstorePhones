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

                Console.WriteLine($"Brand: {phone.Brand} \tType: {phone.Type} \tPrice: {phone.PriceAfterTax} \tBefore tax: {phone.PriceBeforeTax} \tStock left: {phone.Stock}");
                Console.WriteLine($"Description: {phone.Description}\n");
            }
            else if (userChoice == phones.Count)
            {
                Console.WriteLine($"\n\nWrite text to search for.");

                List<Phone> searchResults = PhoneService.Search(Console.ReadLine());
                
                foreach (var phone in searchResults)
                {
                    Console.WriteLine($"{phone.Brand}");
                }
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
    }
}

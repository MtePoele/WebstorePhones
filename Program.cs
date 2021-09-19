using System;
using System.Collections.Generic;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones
{
    class Program
    {
        private static readonly List<Phone> phones = ProductService.GetAllPhones();

        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            for (int i = 0; i < phones.Count; i++)
            {
                Console.WriteLine($"{i}. {phones[i].Brand} {phones[i].Type}");
            }
            Console.Write("\nUw keuze: ");

            int userChoice = -1;

            try
            {
                userChoice = int.Parse(Console.ReadKey().KeyChar.ToString());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer. Kies een nummer 0-4.\n");
            }

            if (userChoice > -1 && userChoice < phones.Count)
            {
                Console.Clear();
                Phone phone = ProductService.GetPhone(userChoice);
                Console.WriteLine($"Brand: {phone.Brand} \tType: {phone.Type} \tPrice: {phone.PriceAfterTax} \tBefore tax: {phone.PriceBeforeTax}");
                Console.WriteLine($"Description: {phone.Description}\n");
                //ShowResults(userChoice);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer. Kies een nummer 0-4.\n");
            }

            MainMenu();
        }
    }
}

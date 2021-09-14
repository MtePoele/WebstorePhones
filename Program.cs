using System;
using System.Collections.Generic;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones
{
    class Program
    {
        private static readonly List<Phone> phones = PhoneService.MakeList();

        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            Console.WriteLine(
                "Kies een telefoonmerk:\n" +
                "0. Huawei\n" +
                "1. Samsung\n" +
                "2. Apple\n" +
                "3. Google\n" +
                "4. Xiaomi");
            Console.WriteLine();

            Console.Write("Uw keuze: ");

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
                ShowResults(userChoice);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer. Kies een nummer 0-4.\n");
            }

            MainMenu();
        }

        private static void ShowResults(int userChoice)
        {
            Console.Clear();

            Console.WriteLine($"{phones[userChoice].Brand} {phones[userChoice].Type}, Price: {phones[userChoice].PriceAfterTax}");
            Console.WriteLine(phones[userChoice].Description);
            Console.WriteLine();
            Console.WriteLine("Druk op een willekeurige toets om terug te gaan naar het hoofdmenu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

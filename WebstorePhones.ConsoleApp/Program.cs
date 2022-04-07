using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebstorePhones.Business;
using WebstorePhones.Business.Extensions;
using WebstorePhones.Business.Loggers;
using WebstorePhones.Business.Repositories;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones
{
    class Program
    {
        static readonly Dictionary<int, Phone> phonesDictionary = new();
        private static IPhoneService _phoneService;

        public static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IPhoneService, PhoneService>()
                .AddScoped<IBrandService, BrandService>()
                .AddScoped<ILogger, FileLogger>()
                .AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>))
                .AddDbContext<DataContext>(x => x.UseSqlServer(ConfigurationManager.AppSettings.Get("connectionString")), ServiceLifetime.Scoped)
                .BuildServiceProvider();

            _phoneService = serviceProvider.GetService<IPhoneService>();

            GetAllPhones();

            while (true)
            {
                await MainMenuAsync();
            }
        }

        private static async Task MainMenuAsync()
        {
            PrintMainMenu();

            int userChoice = AskUserChoice();

            await ExecuteUserChoiceAsync(userChoice);
        }

        private static int AskUserChoice()
        {
            int userChoice = 0;

            try
            {
                userChoice = int.Parse(Console.ReadKey().KeyChar.ToString());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine($"Invalid input. Chose a number between 0 and {phonesDictionary.Count}.\n");
            }

            return userChoice;
        }

        private static void PrintMainMenu()
        {
            foreach (var phone in phonesDictionary)
            {
                Console.WriteLine($"{phone.Key}. {phone.Value.Brand.BrandName} \t{phone.Value.Type}");
            }
            Console.WriteLine($"{phonesDictionary.Count + 1}. Search");
            Console.WriteLine($"{phonesDictionary.Count + 2}. Exit");

            Console.Write("\nUw keuze: ");
        }

        private static async Task ExecuteUserChoiceAsync(int userChoice)
        {
            if (userChoice > 0 && userChoice <= phonesDictionary.Count)
            {
                ShowChosenPhone(userChoice);
            }
            else if (userChoice == phonesDictionary.Count + 1)
            {
                Console.Clear();
                Console.WriteLine($"Enter text to search for.");

                string searchInput = Console.ReadLine();

                await RunSearchAsync(searchInput);

                Console.WriteLine("Press any key to return to main menu.");
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
                Console.WriteLine($"Invalid input. Chose a number between 1 and {phonesDictionary.Count}.\n");
            }
        }

        private static async Task RunSearchAsync(string searchInput)
        {
            if (searchInput.Length > 0)
            {
                List<Phone> searchResults = (await _phoneService.SearchAsync(searchInput)).ToList();
                Console.WriteLine();

                if (searchResults.Count == 0)
                {
                    Console.WriteLine("No matches found.");
                }
                else
                {
                    PrintListOfPhones(searchResults);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter at least one character.");
            }
        }

        private static void ShowChosenPhone(int userChoice)
        {
            Console.Clear();

            Phone phone = phonesDictionary[userChoice];
            PrintResults(phone);
        }

        private static void GetAllPhones()
        {
            List<Phone> phonesList = _phoneService.Get().ToList();

            for (int i = 0; i < phonesList.Count; i++)
            {
                phonesDictionary.Add(i + 1, phonesList[i]);
            }
        }

        private static void PrintListOfPhones(List<Phone> searchResults)
        {
            Console.Clear();
            foreach (var phone in searchResults)
            {
                PrintResults(phone);
            }
        }

        private static void PrintResults(Phone phone)
        {
            Console.WriteLine($"Brand: {phone.Brand.BrandName} \tType: {phone.Type} \tPrice: {phone.PriceWithTax} \tWithout VAT: {phone.PriceWithoutVat()} \tStock: {phone.Stock}");
            Console.WriteLine($"Description: {phone.Description}\n");
        }
    }
}
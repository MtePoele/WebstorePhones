﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WebstorePhones.Business.Extensions;
using WebstorePhones.Business.Repositories;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebstorePhones.Business;

namespace WebstorePhones
{
    class Program
    {
        static readonly Dictionary<int, Phone> phonesDictionary = new();
        private static IPhoneService _phoneService;

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IPhoneService, PhoneService>()
                .AddScoped<IBrandService, BrandService>()
                .AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>))
                .AddDbContext<DataContext>(x => x.UseSqlServer(Constants.ConnectionString), ServiceLifetime.Scoped)
                .BuildServiceProvider();

            _phoneService = serviceProvider.GetService<IPhoneService>();

            GetAllPhones();

            while (true)
            {
                MainMenu();
            }
        }

        // TODO split into multiple methods to reduce complexity.
        private static void MainMenu()
        {
            foreach (var phone in phonesDictionary)
            {
                Console.WriteLine($"{phone.Key}. {phone.Value.Brand.BrandName} \t{phone.Value.Type}");
            }
            Console.WriteLine($"{phonesDictionary.Count + 1}. Search");
            Console.WriteLine($"{phonesDictionary.Count + 2}. Exit");

            Console.Write("\nUw keuze: ");

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

            if (userChoice > 0 && userChoice <= phonesDictionary.Count)
            {
                Console.Clear();

                Phone phone = phonesDictionary[userChoice];
                PrintResults(phone);
            }
            else if (userChoice == phonesDictionary.Count + 1)
            {
                Console.Clear();
                Console.WriteLine($"Enter text to search for.");

                string searchInput = Console.ReadLine();

                if (searchInput.Length > 0)
                {
                    List<Phone> searchResults = _phoneService.Search(searchInput).ToList();
                    Console.WriteLine();

                    if (searchResults.Count == 0)
                    {
                        Console.WriteLine("No matches found.");
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
                    Console.WriteLine("Invalid input. Enter at least one character.");
                }

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

        private static void GetAllPhones()
        {
            List<Phone> phonesList = _phoneService.Get().ToList();

            for (int i = 0; i < phonesList.Count; i++)
            {
                phonesDictionary.Add(i + 1, phonesList[i]);
            }
        }

        private static void PrintResults(Phone phone)
        {
            Console.WriteLine($"Brand: {phone.Brand.BrandName} \tType: {phone.Type} \tPrice: {phone.PriceWithTax} \tWithout VAT: {phone.PriceWithoutVat()} \tStock: {phone.Stock}");
            Console.WriteLine($"Description: {phone.Description}\n");
        }
    }
}
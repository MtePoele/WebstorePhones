using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Entities;

namespace ImportTool.ConsoleApp
{
    class Program
    {
        private static IXmlService _xmlService;
        private static IPhoneService _phoneService;

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IXmlService, XmlService>()
                .AddScoped<IPhoneService, PhoneService>()
                .AddScoped<IBrandService, BrandService>()
                .BuildServiceProvider();

            _xmlService = serviceProvider.GetService<IXmlService>();
            _phoneService = serviceProvider.GetService<IPhoneService>();

            List<Phone> phones = _xmlService.ReadFromXmlFile(args[0]);
            int phonesAdded = _phoneService.AddMissingPhones(phones);

            Console.WriteLine($"{phonesAdded} new phones have been added.");
            Console.ReadLine();
        }
    }
}

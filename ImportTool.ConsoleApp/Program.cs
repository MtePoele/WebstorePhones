using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace ImportTool.ConsoleApp
{
    class Program
    {
        private readonly IXmlService _xmlService;
        private readonly IPhoneService _phoneService;

        public Program(IXmlService xmlService, IPhoneService phoneService)
        {
            _xmlService = xmlService;
            _phoneService = phoneService;
        }

          void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IXmlService, XmlService>()
                .AddScoped<IPhoneService, PhoneService>()
                .BuildServiceProvider();

            var xmlService = serviceProvider.GetService<XmlService>();
            var phoneService = serviceProvider.GetService<PhoneService>();

            // TODO Null reference exceptions. Not an object.
            List<Phone> phones = xmlService.ReadFromXmlFile(args[0]);
            int phonesAdded = phoneService.AddMissingPhones(phones);
            Console.WriteLine($"{phonesAdded} new phones have been added.");
            Console.ReadLine();
        }
    }
}

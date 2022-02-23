using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using WebstorePhones.Business;
using WebstorePhones.Business.Loggers;
using WebstorePhones.Business.Repositories;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace ImportTool.ConsoleApp
{
    class Program
    {
        private static IXmlService _xmlService;
        private static IPhoneService _phoneService;

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                   .AddScoped<IXmlService, XmlService>()
                   .AddScoped<IPhoneService, PhoneService>()
                   .AddScoped<IBrandService, BrandService>()
                   .AddScoped<ILogger, FileLogger>()
                   .AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>))
                   .AddDbContext<DataContext>(x => x.UseSqlServer(ConfigurationManager.AppSettings.Get("connectionString")), ServiceLifetime.Scoped)
                   .BuildServiceProvider();

            _xmlService = serviceProvider.GetService<IXmlService>();
            _phoneService = serviceProvider.GetService<IPhoneService>();

            List<Phone> phones = _xmlService.ReadFromXmlFile(args[0]);
            int phonesAdded = await _phoneService.AddMissingPhonesAsync(phones);

            Console.WriteLine($"{phonesAdded} new phones have been added.");
            Console.ReadLine();
        }
    }
}

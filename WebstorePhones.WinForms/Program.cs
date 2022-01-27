using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using WebstorePhones.Business;
using WebstorePhones.Business.Loggers;
using WebstorePhones.Business.Repositories;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.WinForms
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ILogger, FileLogger>();
            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Constants.ConnectionString), ServiceLifetime.Scoped);
            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new PhoneOverview());
        }
    }
}

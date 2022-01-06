using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business
{
    class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-I9V7KFJQ;Database=WebstorePhones;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 1,
                BrandId = 1,
                Type = "iPhone 1",
                Description = "Old phone",
                Stock = 0,
                PriceWithTax = 100
            });
            modelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 2,
                BrandId = 2,
                Type = "Galaxy",
                Description = "Doesn't look like the night's sky.",
                Stock = 0,
                PriceWithTax = 100
            });
            modelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 3,
                BrandId = 3,
                Type = "3315",
                Description = "Very old phone",
                Stock = 0,
                PriceWithTax = 100
            });

            modelBuilder.Entity<Brand>().HasData(new Brand 
            { 
                Id = 1, 
                BrandName = "Apple" 
            });
            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 2,
                BrandName = "Samsung"
            });
            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 3,
                BrandName = "Nokia"
            });
        }
    }
}

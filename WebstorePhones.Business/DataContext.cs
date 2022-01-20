﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Business
{
    [ExcludeFromCodeCoverage]
    public class DataContext : DbContext
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
            optionsBuilder.UseSqlServer(Constants.ConnectionString);
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

            modelBuilder.Entity<Brand>()
                .HasIndex(x => x.BrandName)
                .IsUnique();
        }
    }
}

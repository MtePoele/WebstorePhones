﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebstorePhones.Business;

namespace WebstorePhones.Business.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220106142040_AttemptingToCreateDatabase2")]
    partial class AttemptingToCreateDatabase2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebstorePhones.Domain.Objects.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BrandName = "Apple"
                        },
                        new
                        {
                            Id = 2L,
                            BrandName = "Samsung"
                        },
                        new
                        {
                            Id = 3L,
                            BrandName = "Nokia"
                        });
                });

            modelBuilder.Entity("WebstorePhones.Domain.Objects.Phone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceWithTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BrandId = 1L,
                            Description = "Old phone",
                            PriceWithTax = 100m,
                            Stock = 0,
                            Type = "iPhone 1"
                        },
                        new
                        {
                            Id = 2L,
                            BrandId = 2L,
                            Description = "Doesn't look like the night's sky.",
                            PriceWithTax = 100m,
                            Stock = 0,
                            Type = "Galaxy"
                        },
                        new
                        {
                            Id = 3L,
                            BrandId = 3L,
                            Description = "Very old phone",
                            PriceWithTax = 100m,
                            Stock = 0,
                            Type = "3315"
                        });
                });

            modelBuilder.Entity("WebstorePhones.Domain.Objects.Phone", b =>
                {
                    b.HasOne("WebstorePhones.Domain.Objects.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });
#pragma warning restore 612, 618
        }
    }
}

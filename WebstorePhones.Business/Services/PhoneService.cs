using PhoneWebShop.Business.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using WebstorePhones.Business.Repositories;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IBrandService _brandService;

        public PhoneService(IRepository<Phone> phoneRepository, IBrandService brandService)
        {
            _phoneRepository = phoneRepository;
            _phoneRepository.ConvertEntry = ConvertEntry;
            _brandService = brandService;
        }

        public PhoneService()
        {

        }

        public Phone Get(int id)
        {
            return _phoneRepository.Get(
                "SELECT p.Id, b.BrandName, p.Type, p.Description, p.PriceWithTax, p.Stock, b.Id " +
                "FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
                "WHERE p.BrandId = {id}"
                );
        }

        public IEnumerable<Phone> Get()
        {
            // TODO remove local variable
                var a = _phoneRepository.GetRecords(
                "SELECT p.Id, b.BrandName, p.Type, p.Description, p.PriceWithTax, p.Stock, b.Id  " +
                "FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
                "WHERE p.BrandId = b.Id"
                );
            return a.OrderBy(x => x.Brand.BrandName);
        }

        public IEnumerable<Phone> Search(string query)
        {
            return _phoneRepository.GetRecords(
                "SELECT phones.Id, brands.BrandName, phones.Type, phones.Description, phones.PriceWithTax, phones.Stock " +
                "FROM phoneshop.dbo.phones " +
                "INNER JOIN brands ON phones.BrandId = brands.Id " +
                $"WHERE brands.BrandName LIKE '%{query}%' OR phones.Type LIKE '%{query}%' OR phones.Description LIKE '%{query}%'"
                ).OrderBy(x => x.Brand);
        }

        public int AddMissingPhones(List<Phone> phones)
        {
            int phonesAdded = 0;
            foreach (var phone in phones)
            {
                if (PhoneNotInDatabase(phone))
                {
                    AddToDatabase(phone);
                    phonesAdded++;
                }
            }
            return phonesAdded;
        }

        public void AddToDatabase(Phone phone)
        {
            SqlCommand command = new(
                $"INSERT INTO phoneshop.dbo.phones (BrandId, Type, Description, PriceWithTax, Stock) " +
                $"VALUES ((SELECT Id FROM phoneshop.dbo.brands WHERE BrandName = '{phone.Brand}'), @Type, @Description, @PriceWithTax, @Stock)"
            );

            command.Parameters.Add("@Type", SqlDbType.VarChar).Value = phone.Type;
            command.Parameters.Add("@Description", SqlDbType.VarChar).Value = phone.Description;
            command.Parameters.Add("@PriceWithTax", SqlDbType.Decimal).Value = phone.PriceWithTax;
            command.Parameters.Add("@Stock", SqlDbType.BigInt).Value = phone.Stock;

            _phoneRepository.ExecuteNonQuery(command);
        }

        public void Delete(long id)
        {
            SqlCommand command = new(
                $"DELETE FROM phoneshop.dbo.phones " +
                $"WHERE phones.Id = @Id "
                );
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;

             _phoneRepository.ExecuteNonQuery(command);
        }

        public Phone PopulateRecord(SqlDataReader reader)
        {
            return new Phone()
            {
                Id = reader.GetInt64(0),
                Brand = new Brand()
                {
                    Id = reader.GetInt64(6),
                    BrandName = reader.GetString(1)
                },
                Type = reader.GetString(2),
                Description = reader.GetString(3),
                PriceWithTax = reader.GetDecimal(4),
                Stock = reader.GetInt32(5)
            };
        }

        private Phone ConvertEntry(SqlDataReader reader)
        {
            return new Phone
            {
                Id = reader.GetInt64(0),
                Brand = new Brand()
                {
                    Id = reader.GetInt64(6),
                    BrandName = reader.GetString(1)
                },
                Type = reader.GetString(2),
                Description = reader.GetString(3),
                PriceWithTax = reader.GetDecimal(4),
                Stock = reader.GetInt32(5)
            };
        }

        private bool PhoneNotInDatabase(Phone phoneToLookFor)
        {
            List<Phone> phones = _phoneRepository.GetRecords(
                "SELECT phones.Id, brands.BrandName, phones.Type, phones.Description, phones.PriceWithTax, phones.Stock " +
                "FROM phoneshop.dbo.phones " +
                "INNER JOIN brands ON phones.BrandId = brands.Id " +
                $"WHERE brands.BrandName LIKE '{phoneToLookFor.Brand}' AND phones.Type LIKE '{phoneToLookFor.Type}'"
                ).ToList();

            if (phones.Count == 0)
                return true;
            else
                return false;
        }
    }
}
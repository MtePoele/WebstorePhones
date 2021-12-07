using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebstorePhones.Business.Repositories;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Services
{
    public class PhoneService : AdoRepository<Phone>, IPhoneService
    {
        private readonly IBrandService _brandService;

        public PhoneService(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        public PhoneService()
        {
        }

        public Phone Get(int id)
        {
            return Get(
                "SELECT p.Id, b.BrandName, p.Type, p.Description, p.PriceWithTax, p.Stock " +
                "FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
                "WHERE p.BrandId = {id}"
                );
        }

        public IEnumerable<Phone> Get()
        {
            return GetRecords(
                "SELECT p.Id, b.BrandName, p.Type, p.Description, p.PriceWithTax, p.Stock " +
                "FROM phoneshop.dbo.phones AS p, phoneshop.dbo.brands AS b " +
                "WHERE p.BrandId = b.Id"
                ).OrderBy(x => x.Brand);
        }

        public IEnumerable<Phone> Search(string query)
        {
            return GetRecords(
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
            _brandService.AddToDatabase(phone);

            SqlCommand command = new(
                $"INSERT INTO phoneshop.dbo.phones (BrandId, Type, Description, PriceWithTax, Stock) " +
                $"VALUES ((SELECT Id FROM phoneshop.dbo.brands WHERE BrandName = '{phone.Brand}'), @Type, @Description, @PriceWithTax, @Stock)"
            );

            command.Parameters.Add("@Type", SqlDbType.VarChar).Value = phone.Type;
            command.Parameters.Add("@Description", SqlDbType.VarChar).Value = phone.Description;
            command.Parameters.Add("@PriceWithTax", SqlDbType.Decimal).Value = phone.PriceWithTax;
            command.Parameters.Add("@Stock", SqlDbType.BigInt).Value = phone.Stock;

            ExecuteNonQuery(command);
        }

        public void Delete(long id)
        {
            SqlCommand command = new(
                $"DELETE FROM phoneshop.dbo.phones " +
                $"WHERE phones.Id = @Id "
                );
            command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;

            ExecuteNonQuery(command);
        }

        public override Phone PopulateRecord(SqlDataReader reader)
        {
            return new Phone()
            {
                Id = reader.GetInt64(0),
                Brand = reader.GetString(1),
                Type = reader.GetString(2),
                Description = reader.GetString(3),
                PriceWithTax = reader.GetDecimal(4),
                Stock = reader.GetInt32(5)
            };
        }

        private bool PhoneNotInDatabase(Phone phoneToLookFor)
        {
            List<Phone> phones = GetRecords(
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
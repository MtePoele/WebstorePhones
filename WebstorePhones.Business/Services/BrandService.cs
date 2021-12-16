using System.Data;
using System.Data.SqlClient;
using WebstorePhones.Business.Repositories;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Business.Services
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public void AddToDatabase(Phone phone)
        {
            SqlCommand command = new(
                $"IF NOT EXISTS (SELECT BrandName FROM phoneshop.dbo.brands WHERE BrandName = @Brand)" +
                $"INSERT INTO phoneshop.dbo.brands (BrandName) VALUES (@Brand)"
                );
            command.Parameters.Add("@Brand", SqlDbType.VarChar).Value = phone.Brand;

            _brandRepository.ExecuteNonQuery(command);
        }

        public long GetBrandId(Phone phone)
        {
            return _brandRepository.Get(
                "SELECT b.Id " +
                "FROM phoneshop.dbo.brands AS b " +
                $"WHERE b.BrandName = {phone.Brand}"
            )
                .Id;
        }
    }
}
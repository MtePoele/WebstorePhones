using System.Data;
using System.Data.SqlClient;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Entities;

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
            
        }

        public long GetBrandId(Phone phone)
        {
            
        }
    }
}
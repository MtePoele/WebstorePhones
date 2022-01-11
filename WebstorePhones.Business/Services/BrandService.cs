using System.Data;
using System.Data.SqlClient;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Entities;
using System.Collections.Generic;

namespace WebstorePhones.Business.Services
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public Brand GetById(long id)
        {
            return _brandRepository.GetById(id);
        }

        public void AddToDatabase(Phone phone)
        {
            
        }
    }
}
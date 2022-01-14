using System.Data;
using System.Data.SqlClient;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public long AddBrandIdToPhone(string brandName)
        {
            long foundId = GetBrandId(brandName);

            if (foundId == 0)
            {
                _brandRepository.Create(new Brand() { BrandName = brandName });
                foundId = GetBrandId(brandName);
            }

            return foundId;
        }

        private long GetBrandId(string brandName)
        {
            return _brandRepository.GetAll()
                .Where(x => x.BrandName.ToLower() == brandName.ToLower())
                .FirstOrDefault()?.Id ?? 0L;
        }
    }
}
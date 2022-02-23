﻿using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        // TODO This method is no longer needed for functionality. Kenji said to keep it for now.
        public Brand GetById(long id)
        {
            return _brandRepository.GetById(id);
        }

        public async Task<long> AddBrandIdToPhoneAsync(string brandName)
        {
            long foundId = GetBrandId(brandName);

            if (foundId == 0)
            {
                await _brandRepository.CreateAsync(new Brand() { BrandName = brandName });
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
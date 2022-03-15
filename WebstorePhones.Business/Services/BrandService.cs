using System.Data;
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

        public Brand GetById(long id)
        {
            Brand brand = _brandRepository.GetById(id);

            if (brand == null)
            {
                brand = new();
            }

            return brand;
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

        public async Task<string> CreateBrandAsync(Brand brand)
        {
            if (DoesBrandExist(brand.BrandName))
                return "Brand already exists.";
            else
            {
                await _brandRepository.CreateAsync(brand);
                return "Brand was added.";
            }
        }

        private bool DoesBrandExist(string query)
        {
            return _brandRepository.GetAll().Any(x => x.BrandName == query);
        }

        private long GetBrandId(string brandName)
        {
            return _brandRepository.GetAll()
                .Where(x => x.BrandName.ToLower() == brandName.ToLower())
                .FirstOrDefault()?.Id ?? 0L;
        }
    }
}
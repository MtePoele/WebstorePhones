using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IBrandService _brandService;

        public PhoneService(IRepository<Phone> phoneRepository, IBrandService brandService)
        {
            _phoneRepository = phoneRepository;
            _brandService = brandService;
        }

        public IEnumerable<Phone> Get()
        {
            return _phoneRepository.GetAll().Include(x => x.Brand).OrderBy(y => y.Brand.BrandName).ThenBy(z => z.Type).ToList();
        }

        public IEnumerable<Phone> Search(string query)
        {
            return _phoneRepository.GetAll().Include(x => x.Brand)
                .Where(y =>
            y.Brand.BrandName.ToLower().Contains(query.ToLower()) ||
            y.Type.ToLower().Contains(query.ToLower()) ||
            y.Description.ToLower().Contains(query.ToLower()));
        }

        public int AddMissingPhones(List<Phone> phones)
        {
            int phonesAdded = 0;
            foreach (var phone in phones)
            {
                if (!PhoneInDatabase(phone))
                {
                    AddToDatabase(phone);
                    phonesAdded++;
                }
            }
            return phonesAdded;
        }

        public void Delete(long id)
        {
            _phoneRepository.Delete(id);
        }

        private void AddToDatabase(Phone phone)
        {
            phone.BrandId = _brandService.AddBrandIdToPhone(phone.Brand.BrandName);
            phone.Brand = null;
            _phoneRepository.Create(phone);
        }

        private bool PhoneInDatabase(Phone phoneToLookFor)
        {
            // TODO Ask Wubbo if there's some way to test this even though it involves private methods.
            return Get()
                .Where(x => x.Brand.BrandName == phoneToLookFor.Brand.BrandName)
                .Where(x => x.Type == phoneToLookFor.Type)
                .Where(x => x.Description == phoneToLookFor.Description)
                .Any();
        }
    }
}
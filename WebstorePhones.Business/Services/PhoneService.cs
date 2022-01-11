using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            IEnumerable<Phone> phones = _phoneRepository.GetAll().ToList();

            foreach (Phone phone in phones)
            {
                phone.Brand = _brandService.GetById(phone.BrandId);
            }
            
            return phones;
        }

        public IEnumerable<Phone> Search(string query)
        {
            IEnumerable<Phone> phones = _phoneRepository.GetAll().ToList();

            foreach (Phone phone in phones)
            {
                phone.Brand = _brandService.GetById(phone.BrandId);
            }

            return phones.Where(x =>
            x.Brand.BrandName.ToLower().Contains(query.ToLower()) ||
            x.Type.ToLower().Contains(query.ToLower()) ||
            x.Description.ToLower().Contains(query.ToLower())
            );
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

        }

        public void Delete(long id)
        {

        }

        private bool PhoneNotInDatabase(Phone phoneToLookFor)
        {
            //TODO Fix this
            bool fix = false;
            return fix;
        }
    }
}
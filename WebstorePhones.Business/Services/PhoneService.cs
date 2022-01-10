using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Entities;

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

        //public PhoneService()
        //{

        //}

        public Phone Get(int id)
        {
            
        }

        public IEnumerable<Phone> Get()
        {
            
        }

        public IEnumerable<Phone> Search(string query)
        {
            
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
            
        }
    }
}
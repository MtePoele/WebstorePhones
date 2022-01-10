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
        private readonly DataContext _dataContext;

        public PhoneService(IRepository<Phone> phoneRepository, IBrandService brandService, DataContext dataContext)
        {
            _phoneRepository = phoneRepository;
            _brandService = brandService;
            _dataContext = dataContext;
        }

        //public PhoneService()
        //{

        //}


        public Phone Get(int id)
        {
            Phone fix = new();
            return fix;
        }

        public IEnumerable<Phone> Get()
        {
            var phones = _dataContext.Phones
                .Include(a => a.Brand)
                .ToList();
            return phones;
        }

        public IEnumerable<Phone> Search(string query)
        {
            IEnumerable<Phone> a = null;
            return a;
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
            bool fix = false;
            return fix;
        }
    }
}
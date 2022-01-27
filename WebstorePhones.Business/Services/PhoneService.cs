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
        private readonly ILogger _logger;

        public PhoneService(IRepository<Phone> phoneRepository, IBrandService brandService, ILogger fileLogger)
        {
            _phoneRepository = phoneRepository;
            _brandService = brandService;
            _logger = fileLogger;
        }

        public IEnumerable<Phone> Get()
        {
            return _phoneRepository.GetAll().Include(x => x.Brand).OrderBy(y => y.Brand.BrandName).ThenBy(z => z.Type).ToList();
        }

        public IEnumerable<Phone> Search(string query)
        {
            _logger.Log(WhatHappened.Search, query);

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

            _logger.Log(WhatHappened.PhoneDeleted, id.ToString());
        }

        public void LoggingException(string exceptionMessage)
        {
            _logger.Log(WhatHappened.Exception, exceptionMessage);
        }

        private void AddToDatabase(Phone phone)
        {
            phone.BrandId = _brandService.AddBrandIdToPhone(phone.Brand.BrandName);
            phone.Brand = null;
            _phoneRepository.Create(phone);

            _logger.Log(WhatHappened.PhoneAdded, $"{phone.Brand.BrandName} {phone.Type}");
        }

        private bool PhoneInDatabase(Phone phoneToLookFor)
        {
            return Get()
                .Where(
                x => x.Brand.BrandName == phoneToLookFor.Brand.BrandName &&
                x.Type == phoneToLookFor.Type &&
                x.Description == phoneToLookFor.Description)
                .Any();
        }
    }
}
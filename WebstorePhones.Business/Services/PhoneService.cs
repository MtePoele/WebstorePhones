using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IBrandService _brandService;
        private readonly ILogger _logger;

        public PhoneService(IRepository<Phone> phoneRepository, IBrandService brandService, ILogger logger)
        {
            _phoneRepository = phoneRepository;
            _brandService = brandService;
            _logger = logger;
        }

        public IEnumerable<Phone> Get()
        {
            return _phoneRepository.GetAll().Include(x => x.Brand).OrderBy(y => y.Brand.BrandName).ThenBy(z => z.Type).ToList();
        }

        public Phone GetById(long id)
        {
            IEnumerable<Phone> phones = _phoneRepository.GetAll().Include(x => x.Brand).Where(y => y.Id == id);

            return phones.FirstOrDefault();
        }

        public async Task<IEnumerable<Phone>> SearchAsync(string query)
        {
            await _logger.LogAsync(WhatHappened.Search, query);

            return _phoneRepository.GetAll().Include(x => x.Brand)
                .Where(y =>
            y.Brand.BrandName.ToLower().Contains(query.ToLower()) ||
            y.Type.ToLower().Contains(query.ToLower()) ||
            y.Description.ToLower().Contains(query.ToLower()));
        }

        public async Task<int> AddMissingPhonesAsync(List<Phone> phones)
        {
            int phonesAdded = 0;
            foreach (var phone in phones)
            {
                if (!PhoneInDatabase(phone))
                {
                    await AddToDatabaseAsync(phone);
                    phonesAdded++;
                }
            }
            return phonesAdded;
        }

        public async Task DeleteAsync(long id)
        {
            _phoneRepository.Delete(id);

            await _logger.LogAsync(WhatHappened.PhoneDeleted, id.ToString());
        }

        // TODO No use for exception logging (yet?)
        public async Task LoggingExceptionAsync(string exceptionMessage)
        {
            await _logger.LogAsync(WhatHappened.Exception, exceptionMessage);
        }

        private async Task AddToDatabaseAsync(Phone phone)
        {
            string brandName = phone.Brand.BrandName;

            phone.BrandId = await _brandService.AddBrandIdToPhoneAsync(phone.Brand.BrandName);
            phone.Brand = null;
            await _phoneRepository.CreateAsync(phone);

            await _logger.LogAsync(WhatHappened.PhoneAdded, $"{brandName}, {phone.Type}");
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
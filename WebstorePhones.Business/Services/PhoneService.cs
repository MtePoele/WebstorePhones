using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

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

            return phones.OrderBy(x => x.Brand.BrandName);
        }

        public IEnumerable<Phone> Search(string query)
        {
            // TODO Ask Kenji how to optimize this to search in the database and include Brands in that search at the same time, without using GetAll() first
            // Maybe make EFRepo.GetAll() virtual and override it to what I want .. somewhere in the code? Or not possible because of DI?
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
            Debug.WriteLine(phone.BrandId);
            phone.Brand = null;
            _phoneRepository.Create(phone);
            Debug.WriteLine("BrandId" + phone.BrandId);
        }

        private bool PhoneInDatabase(Phone phoneToLookFor)
        {
            return Get()
                .Where(x => x.Brand.BrandName == phoneToLookFor.Brand.BrandName)
                .Where(x => x.Type == phoneToLookFor.Type)
                .Where(x => x.Description == phoneToLookFor.Description)
                .Any();
        }
    }
}
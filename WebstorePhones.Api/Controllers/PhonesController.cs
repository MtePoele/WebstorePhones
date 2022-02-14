﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : Controller
    {
        private readonly IPhoneService _phoneService;

        public PhonesController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        public ActionResult GetPhones(string query)
        {
            List<Phone> phones;

            if (query == null)
            {
                phones = _phoneService.Get().ToList();
            }
            else
            {
                phones = _phoneService.Search(query).ToList();
            }
            if (!phones.Any())
                return NotFound();

            return Ok(phones);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            Phone phone = _phoneService.GetById(id);

            return Ok(phone);
        }

        [HttpPost]
        public ActionResult Create(Phone phone)
        {
            List<Phone> phones = new();
            phones.Add(phone);

            _phoneService.AddMissingPhones(phones);

            return Ok(phone);
        }
    }
}
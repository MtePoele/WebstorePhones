using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : Controller
    {
        private readonly IPhoneService _phoneService;
        private readonly ILogger _logger;

        public PhonesController(IPhoneService phoneService, ILogger logger)
        {
            _phoneService = phoneService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhones(string query)
        {
            List<Phone> phones = string.IsNullOrEmpty(query) ? _phoneService.Get().ToList() : (await _phoneService.SearchAsync(query)).ToList();

            return Ok(phones);
        }

        [Route("getbyid")]
        [HttpGet]
        public ActionResult Get(long id)
        {
            Phone phone = _phoneService.GetById(id);

            return Ok(phone);
        }

        [Route("post")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Phone phone)
        {
            phone.Id = 0;

            List<Phone> phones = new();
            phones.Add(phone);

            await _phoneService.AddMissingPhonesAsync(phones);

            return Ok(phone);
        }

        [Route("delete")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _phoneService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await _logger.LogAsync(WhatHappened.Exception, ex.Message);

                return BadRequest();
            }

            return Ok($"Phone with id {id} has been deleted.");
        }
    }
}

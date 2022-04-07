using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public PhonesController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhones(string query)
        {
            List<Phone> phones = string.IsNullOrEmpty(query) ? _phoneService.Get().ToList() : (await _phoneService.SearchAsync(query)).ToList();

            return Ok(phones);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            Phone phone = _phoneService.GetById(id);

            return Ok(phone);
        }

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
    }
}

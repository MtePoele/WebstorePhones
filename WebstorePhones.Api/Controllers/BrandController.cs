using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly IBrandService _brandService;
        private readonly ILogger _logger;

        public BrandController(IRepository<Brand> brandRepository, IBrandService brandService, ILogger logger)
        {
            _brandRepository = brandRepository;
            _brandService = brandService;
            _logger = logger;
        }

        [Route("Create")]
        [HttpPost]
        // TODO Needs to only take a brandname, problems ensue if ID is filled.
        public async Task<IActionResult> Create(string brandName)
        {
            Brand brand = new()
            {
                BrandName = brandName
            };

            try
            {
                string message = await _brandService.CreateBrandAsync(brand);

                return Ok(message);
            }
            catch (Exception ex)
            {
                await _logger.LogAsync(WhatHappened.Exception, ex.Message);

                return BadRequest(ex);
            }
        }

        [Route("getbyid")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                string brandName = _brandService.GetById(id).BrandName;

                string message = string.IsNullOrEmpty(brandName) ? "Brand doesn't exist." : brandName;

                return Ok(message);
            }
            catch (Exception ex)
            {
                await _logger.LogAsync(WhatHappened.Exception, ex.Message);

                return BadRequest();
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                _brandRepository.Delete(id);
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

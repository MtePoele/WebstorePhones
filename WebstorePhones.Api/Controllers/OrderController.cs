using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebstorePhones.Api.Models;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly ITokenService _tokenService;
        private readonly IOrderService _orderService;

        public OrderController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager, ITokenService tokenService, IOrderService orderService)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _tokenService = tokenService;
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetOrders()
        {
            List<Order> orders = _orderService.Get(UserId);

            return Ok(orders);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetById(long id)
        {
            string userId = User.FindFirst("Id").Value;

            List<Order> orders = _orderService.Get(UserId);

            return Ok(orders);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(List<CreateOrderInputModel> createOrderInputModel)
        {
            List<ProductsPerOrder> productsPerOrders = new();

            foreach (var item in createOrderInputModel)
            {
                productsPerOrders.Add(
                    new ProductsPerOrder
                    {
                        PhoneId = item.PhoneId,
                        Amount = item.Amount
                    });
            }

            string userId = User.FindFirst("Id").Value;

            await _orderService.CreateAsync(productsPerOrders, userId);

            return Ok();
        }
    }
}

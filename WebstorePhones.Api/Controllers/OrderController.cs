using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using WebstorePhones.Api.Models;
using WebstorePhones.Business.Builders;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
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
        public async Task<IActionResult> GetOrders()
        {
            // get IdentityUser
            var currentUserId = HttpContext.User.Identity;

            //List<Order> phones = string.IsNullOrEmpty(query) ? _orderService.Get().ToList() : (await _orderService.SearchAsync(query)).ToList();

            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(Order order)
        {
            // TODO Working on this

            OrderBuilder orderBuilder = new OrderBuilder();
            var a = orderBuilder
                .SetCustomerId(HttpContext.User.Identity.Name)
                .SetTotalPrice(order.TotalPrice)
                .SetVatPercentage(order.VatPercentage)
                .SetOrderDate(order.OrderDate)
                .SetProductsPerOrderList(order.ProductsPerOrderList)
                .SetDeleted(false)
                .SetReason(order.Reason)
                .Build();

            return Ok(orderBuilder);
        }

        /*
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            IdentityUser identityUser = new()
            {
                UserName = user.Username,
                Email = user.Email,
            };

            try
            {
                IdentityResult createdUser = await _userManager.CreateAsync(identityUser, user.Password);

                if (createdUser == IdentityResult.Success)
                    return Ok(user);
                else
                    return BadRequest(createdUser.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(login.Username);

                    List<Claim> claims = new()
                    {
                        new Claim("Id", user.Id),
                    };
                    string tokenString = _tokenService.Generate(claims);

                    return Ok(new
                    {
                        Success = true,
                        tokenString,
                        role = "Guest"
                    });
                }

            }
            return BadRequest();
        }
        */
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebstorePhones.Api.Models;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly ITokenService _tokenService;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _tokenService = tokenService;
        }

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
    }
}

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Services
{
    public class TokenService : ITokenService
    {
        public string Generate(List<Claim> claims)
        {
            if (claims is null || !claims.Any())
                throw new ArgumentNullException(nameof(claims));
            var mySecurityKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes("C86B616E-C748-47DF-9B04-B1566F955D3E"));
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = "http://localhost/issuer",
                Audience = "http://localhost/audience",
                SigningCredentials = new SigningCredentials(
            mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            });
            return tokenHandler.WriteToken(token);
        }

    }
}

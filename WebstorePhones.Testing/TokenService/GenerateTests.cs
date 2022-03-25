using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebstorePhones.Business.Services;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using WebstorePhones.Domain.Models.Configuration;
using Moq;

namespace WebstorePhones.Testing.TokenService
{
    public class GenerateTests
    {
        private readonly Mock<IOptions<JwtSettings>> _mockJwtOptions = new();
        private readonly Business.Services.TokenService _tokenService;

        public GenerateTests()
        {
            _mockJwtOptions.SetupGet(x => x.Value).Returns(new JwtSettings
            {
                Audience = "https://localhost/audience",
                Issuer = "https://localhost/issuer",
                SignKey = "31041149-ed1e-4b17-9b40-143e72dceacf" // Random GUID
            });
            _tokenService = new Business.Services.TokenService(_mockJwtOptions.Object);
        }

        [Fact]
        public void Should_ContainAJWTTokenString()
        {
            List<Claim> claims = new()
            {
                new Claim("1", "1"),
            };
            string sut = _tokenService.Generate(claims);

            Assert.Contains("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9", sut);
        }

        [Fact]
        public void Should_ReturnNull()
        {
            List<Claim> claims = new();

            Assert.Throws<ArgumentNullException>(() => _tokenService.Generate(claims));
        }
    }
}

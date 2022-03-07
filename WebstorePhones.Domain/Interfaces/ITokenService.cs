using System.Collections.Generic;
using System.Security.Claims;

namespace WebstorePhones.Domain.Interfaces
{
    public interface ITokenService
    {
        string Generate(List<Claim> claims);
    }
}

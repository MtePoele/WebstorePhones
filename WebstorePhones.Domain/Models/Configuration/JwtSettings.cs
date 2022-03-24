using System.Diagnostics.CodeAnalysis;

namespace WebstorePhones.Domain.Models.Configuration
{
    [ExcludeFromCodeCoverage]
    public class JwtSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SignKey { get; set; }
    }
}

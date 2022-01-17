using System.Diagnostics.CodeAnalysis;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Brand : IEntity
    {
        public long Id { get; set; }
        public string BrandName { get; set; }
    }
}

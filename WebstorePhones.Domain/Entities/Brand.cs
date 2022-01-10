using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Domain.Entities
{
    public class Brand : IEntity
    {
        public long Id { get; set; }
        public string BrandName { get; set; }
    }
}

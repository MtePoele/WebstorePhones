using System.Diagnostics.CodeAnalysis;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Log : IEntity
    {
        public long Id { get; set; }
        public string DateTimeOfEvent { get; set; }
        public string NameOfEvent { get; set; }
        public string Details { get; set; }
    }
}

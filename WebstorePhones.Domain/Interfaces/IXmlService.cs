using System.Collections.Generic;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IXmlService
    {
        List<Phone> ReadFromXmlFile(string xmlPath);
    }
}

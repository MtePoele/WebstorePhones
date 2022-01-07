using System.Collections.Generic;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IXmlService
    {
        /// <summary>
        /// Takes the path to xml file from args[0]. Then reads the file and returns List<Phone> with all phones.
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        List<Phone> ReadFromXmlFile(string xmlPath);
    }
}

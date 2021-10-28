using System.Collections.Generic;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IPhoneService
    {
        /// <summary>
        /// Returns all phones as an IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerable<Phone> Get();

        /// <summary>
        /// Returns one phone based on id provided.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Phone Get(int id);

        /// <summary>
        /// Takes a string as parameter, then searches for it. Is not case sensitive.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<Phone> Search(string query);

        /// <summary>
        /// Reads all phones in XML file. Returns a List<Phone> with all phones and their respective values.
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        List<Phone> ReadFromXmlFile(string xmlPath);
    }
}

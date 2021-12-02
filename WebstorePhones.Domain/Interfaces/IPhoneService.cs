using System.Collections.Generic;
using System.Data.SqlClient;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IPhoneService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Phone Get(int id);
        IEnumerable<Phone> Get();
        IEnumerable<Phone> Search(string query);
        int AddMissingPhones(List<Phone> phones);
        void AddPhoneToDatabase(Phone phone);
        void Delete(long id);
        Phone PopulateRecord(SqlDataReader reader);
    }
}

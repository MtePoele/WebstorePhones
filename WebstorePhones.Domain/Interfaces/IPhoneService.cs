using System.Collections.Generic;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IPhoneService
    {
        IEnumerable<Phone> Get();

        Phone Get(int id);

        IEnumerable<Phone> Search(string query);
    }
}

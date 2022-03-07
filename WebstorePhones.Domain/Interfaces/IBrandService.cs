using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IBrandService
    {
        /// <summary>
        /// Checks if the brand exists in the database, and adds it if it doesn't. Returns brandId
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>long</returns>
        Task<long> AddBrandIdToPhoneAsync(string brandName);
        /// <summary>
        /// Returns a Brand object based on the id provided.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Brand object</returns>
        Brand GetById(long id);
    }
}

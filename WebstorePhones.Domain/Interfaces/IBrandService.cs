using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IBrandService
    {
        /// <summary>
        /// Checks if the brand exists in the database, and adds it if it doesn't.
        /// </summary>
        /// <param name="phone"></param>
        void AddToDatabase(Phone phone);
        /// <summary>
        /// Gets the Id of brand based on phone.brand
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>long</returns>
        long GetBrandId(Phone phone);
    }
}

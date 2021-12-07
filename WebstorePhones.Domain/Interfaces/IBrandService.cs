using WebstorePhones.Domain.Objects;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IBrandService
    {
        /// <summary>
        /// Add Brand name to database.
        /// </summary>
        /// <param name="phone"></param>
        void AddToDatabase(Phone phone);
        /// <summary>
        /// Returns a long with the ID of the phone based on its brand.
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        long GetBrandId(Phone phone);
    }
}

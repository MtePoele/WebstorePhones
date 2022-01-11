using WebstorePhones.Domain.Entities;

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
        /// Returns a Brand object based on the id provided.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Brand object</returns>
        Brand GetById(long id);
    }
}

namespace WebstorePhones.Domain.Interfaces
{
    public interface ITaxService
    {
        /// <summary>
        /// Takes a price with tax inlcuded, and removes the tax. Then returns the result.
        /// </summary>
        /// <param name="priceWithTax"></param>
        /// <returns></returns>
        double CalculateWithoutTax(double priceWithTax);
    }
}

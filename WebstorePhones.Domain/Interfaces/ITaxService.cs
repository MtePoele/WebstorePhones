namespace WebstorePhones.Domain.Interfaces
{
    public interface ITaxService
    {
        double CalculateWithoutTax(double priceWithTax);
    }
}

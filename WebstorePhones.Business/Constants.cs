namespace WebstorePhones.Business
{
    public class Constants
    {
        private const string _connectionString = "Data Source=LAPTOP-I9V7KFJQ;Initial Catalog=WebstorePhones;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string ConnectionString => _connectionString;
    }
}

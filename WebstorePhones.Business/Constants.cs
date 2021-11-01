using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebstorePhones.Business
{
    public class Constants
    {
        private const string connectionString = "Data Source=LAPTOP-I9V7KFJQ;Initial Catalog=phoneshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string ConnectionString => connectionString;
    }
}

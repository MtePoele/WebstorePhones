using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebstorePhones.Api.Models
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

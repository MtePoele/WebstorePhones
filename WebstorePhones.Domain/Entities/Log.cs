using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebstorePhones.Domain.Entities
{
    public class Log
    {
        public DateTime DateTimeOfEvent { get; set; }
        public string NameOfEvent { get; set; }
        public string Type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;

namespace WebstorePhones.Domain.Interfaces
{
    public interface IScraper
    {
        public bool CanExecute(string url);
        public Task<List<Phone>> Execute(string url);
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Repositories
{
    public abstract class EFRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        public EFRepository(DataContext context)
        {
            _context = context;
        }

        public int Id { get; set; }

        public abstract T Create(T entity);

        public abstract void Delete(int id);

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(int id);
    }
}

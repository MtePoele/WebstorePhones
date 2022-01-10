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
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        public EntityFrameworkRepository(DataContext context)
        {
            _context = context;
        }

        public int Id { get; set; }

        public T Create(T entity)
        {
            T a = null;
            return a;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }
    }
}

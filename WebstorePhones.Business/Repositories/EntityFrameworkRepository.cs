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
            _context.Add(entity);
            return entity;
        }

        public void Delete(long id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            // TODO Can't make it ".Include(a => a.Brand)" because T does not contain a Brand.
            return _context.Set<T>();
                //.Include(a => a.Brand);
        }

        public T GetById(long id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }
    }
}

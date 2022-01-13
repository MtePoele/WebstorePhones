﻿using Microsoft.EntityFrameworkCore;
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
            // TODO Add some check to see if BrandId is assigned to some existing brand, or something.
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(long id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        // Oplossing van Thomas, maar kan niet omdat het GetAll() moet zijn, dus zonder parameters.
        //public IEnumerable<T> GetAll(Action<IQueryable<T>> predicate)
        //{
        //    var set = _context.Set<T>();
        //    predicate.Invoke(set);
        //    return set.AsEnumerable();
        //}

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

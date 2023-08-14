using Data.Layer.Access.Entity;
using Data.Layer.Access.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Concrete
{
    public class ProductRepo<T> : IProductRepo
    {
        private readonly DbContext _context;
        public ProductRepo(DbContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Set<Product>().Add(entity);
        }

        public void Delete(Product entity)
        {
            _context.Set<Product>().Remove(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Set<Product>().FindAsync(id);
        }

        public void Update(Product entity)
        {
            _context.Set<Product>().Update(entity);
        }

        Task<Product> IBaseRepo<Product>.GetById(int id)
        {
            return _context.Set<Task<Product>>().Find(id);

        }
    }
}

/*
  void IBaseRepo<Product>.Add(Product entity)
        {
            _context.Set<Product>().Add(entity);
        }

        void IBaseRepo<Product>.Delete(Product entity)
        {
           _context.Set<Product>().Remove(entity);
        }

        IEnumerable<Product> IBaseRepo<Product>.GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        Product IBaseRepo<Product>.GetById(int id)
        {
            return _context.Set<Product>().Find(id); 
        }

        void IBaseRepo<Product>.Update(Product entity)
        {
            _context.Set<Product>().Update(entity);
        }*/
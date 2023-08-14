using Data.Layer.Access.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Concrete
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepo(DbContext context)
        {
            _context = context;
        }

        async void IBaseRepo<T>.Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        async void IBaseRepo<T>.Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        IEnumerable<T> IBaseRepo<T>.GetAll()
        {
            var getall = _context.Set<T>().ToList();
            return getall;
        }

        Task<T> IBaseRepo<T>.GetById(int id)
        {
            return _context.Set<Task<T>>().Find(id);
            
        }

        async void  IBaseRepo<T>.Update(T entity)
        {
             _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

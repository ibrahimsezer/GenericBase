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

        void IBaseRepo<T>.Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        void IBaseRepo<T>.Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        IEnumerable<T> IBaseRepo<T>.GetAll()
        {
            return _context.Set<T>().ToList();
        }

        T IBaseRepo<T>.GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        void IBaseRepo<T>.Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

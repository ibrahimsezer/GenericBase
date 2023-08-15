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
    public abstract class  BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        private readonly DataAccess _context;
        public BaseRepo(DataAccess context)
        {
            _context = context;
        }

        public virtual async  Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        //  async void IBaseRepo<T>.Delete(T entity)
        //{
        //    _context.Set<T>().FindAsync(entity);
        //    _context.Remove(entity);
        //    await _context.SaveChangesAsync();

        //}

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
            
        }

        //public virtual async Task<T> IBaseRepo<T>.GetById(int id)
        //{
        //    return await _context.Set<Task<T>>().Find(id);
            
        //}

        //public virtual async void  IBaseRepo<T>.Update(T entity)
        //{
        //     _context.Set<T>().Update(entity);
        //    await _context.SaveChangesAsync();
        //}
    }
}

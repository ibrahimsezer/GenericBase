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

        public virtual async  Task<T> CreateBase(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();

        }
        public virtual async Task<T> DeleteBase(T entity)
        {
            var delete_unit = await _context.Set<T>().FindAsync(entity.Id);
            //await _context.Set<T>().Include(u => u.Id == entity.Id).ToListAsync();
            // await _context.Set<T>().FindAsync(entity.Id);
            _context.Remove(delete_unit);
            await _context.SaveChangesAsync();
            return null;
        }
   
        public virtual async Task<T> GetUnit(T entity)
        {
           return await _context.Set<T>().FindAsync(entity.Id);
    
        }

        public virtual async Task<T> UpdateBase(T entity)
        {
            var updateUnit = await _context.Set<T>().FirstOrDefaultAsync(u => u.Id == entity.Id);
            await _context.SaveChangesAsync();  
            return updateUnit;
        }

    }
}

using Data.Layer.Access.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Interface
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
       // Task<T>GetById(int id);
        public Task<List<T>> GetAll();
        public Task<T> Create(T entity);
       // void Update(T entity);
       // void Delete(T entity);
    }
}

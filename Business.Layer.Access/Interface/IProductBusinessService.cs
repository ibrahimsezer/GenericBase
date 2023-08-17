using Data.Layer.Access.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Access.Interface
{
    public interface IProductBusinessService
    {
        Task<Product> DeleteProduct(int id);
        Task<List<Product>> GetAllProduct();
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProduct(int id);
    }
}

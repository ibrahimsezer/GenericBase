using Data.Layer.Access.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Interface
{
    public interface IProductRepo
    {
        Task<Product> DeleteProduct(int id);
        Task<List<Product>> GetAllProduct();
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProduct(int id);
        Task<Product> UpdateProduct(int id,Product product);
    }
}
